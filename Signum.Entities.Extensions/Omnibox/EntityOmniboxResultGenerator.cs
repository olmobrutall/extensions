﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Signum.Utilities;
using Signum.Entities.Reflection;
using Signum.Entities.Extensions.Properties;
using System.Text.RegularExpressions;

namespace Signum.Entities.Omnibox
{
    public class EntityOmniboxResultGenenerator : OmniboxResultGenerator<EntityOmniboxResult>
    {
        Dictionary<string, Type> types; 

        public EntityOmniboxResultGenenerator(IEnumerable<Type> schemaTypes)
        {
            types = schemaTypes.Where(t => !t.IsEnumProxy()).ToDictionary(t => Lite.UniqueTypeName(t));
        }

        public int AutoCompleteLimit = 5;

        Regex regex = new Regex(@"^I((?<id>N)|(?<toStr>S))?$", RegexOptions.ExplicitCapture);

        public override IEnumerable<EntityOmniboxResult> GetResults(string rawQuery, List<OmniboxToken> tokens, string tokenPattern)
        {
            Match m = regex.Match(tokenPattern);

            if (!m.Success)
                yield break;

            string ident = tokens[0].Value;

            bool isPascalCase = OmniboxUtils.IsPascalCasePattern(ident);

            var manager = OmniboxParser.Manager;

            var matches = OmniboxUtils.Matches(types, t => t.NiceName(), ident, isPascalCase).Where(a => manager.AllowedType((Type)a.Value));

            if (tokens.Count == 1)
            {
                foreach (var match in matches)
                {
                    yield return new EntityOmniboxResult
                    {
                        Type = (Type)match.Value,
                        TypeMatch = match,
                        Distance = match.Distance,
                    };
                }
            }
            else if (tokens[1].Type == OmniboxTokenType.Number)
            {
                int id;
                if (!int.TryParse(tokens[1].Value, out id))
                    yield break;

                foreach (var match in matches)
                {
                    Lite lite = OmniboxParser.Manager.RetrieveLite((Type)match.Value, id);

                    yield return new EntityOmniboxResult
                    {
                        Type = (Type)match.Value,
                        TypeMatch = match,
                        Id = id,
                        Lite = lite,
                        Distance = match.Distance,
                    };
                }
            }
            else if (tokens[1].Type == OmniboxTokenType.String)
            {
                string pattern = OmniboxUtils.CleanCommas(tokens[1].Value);

                foreach (var match in matches)
                {
                    var autoComplete = OmniboxParser.Manager.AutoComplete((Type)match.Value, null, pattern, AutoCompleteLimit);

                    if (autoComplete.Any())
                    {
                        foreach (Lite lite in autoComplete)
                        {
                            OmniboxMatch distance = OmniboxUtils.Contains(lite, lite.ToString(), pattern);

                            yield return new EntityOmniboxResult
                            {
                                Type = (Type)match.Value,
                                TypeMatch = match,
                                ToStr = pattern,
                                Lite = lite,
                                Distance = match.Distance + distance.Distance,
                                ToStrMatch = distance,
                            };
                        }
                    }
                    else
                    {
                        yield return new EntityOmniboxResult
                        {
                            Type = (Type)match.Value,
                            TypeMatch = match,
                            Distance = match.Distance + 100,
                            ToStr = pattern,
                        };
                    }
                }

            }
        }

    }

    public class EntityOmniboxResult : OmniboxResult
    {
        public Type Type { get; set; }
        public OmniboxMatch TypeMatch { get; set; }

        public int? Id { get; set; }

        public string ToStr { get; set; }
        public OmniboxMatch ToStrMatch { get; set; }

        public Lite Lite { get; set; }

        public override string ToString()
        {
            if (Id.HasValue)
                return "{0} {1}".Formato(Reflector.CleanTypeName(Type), Id, Lite.TryToString() ?? Resources.NotFound);

            if (ToStr != null)
                return "{0} \"{1}\"".Formato(Reflector.CleanTypeName(Type), ToStr, Lite.TryToString() ?? Resources.NotFound);

            return Reflector.CleanTypeName(Type);
        }
    }
}
