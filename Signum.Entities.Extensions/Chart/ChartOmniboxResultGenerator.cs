﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Signum.Utilities;
using Signum.Entities.Reflection;
using Signum.Entities.Extensions.Properties;
using System.Text.RegularExpressions;
using Signum.Entities.Chart;
using Signum.Entities.Omnibox;
using Signum.Entities.DynamicQuery;

namespace Signum.Entities.Chart
{
    public class ChartOmniboxResultGenerator : OmniboxResultGenerator<ChartOmniboxResult>
    {
        static Dictionary<string, object> queries;
        public ChartOmniboxResultGenerator(IEnumerable<object> queryNames)
        {
            queries = queryNames.ToDictionary(OmniboxParser.Manager.CleanQueryName);
        }

        public string Keyword = "Chart";
        public Func<string> NiceName = () => Resources.Chart;

        Regex regex = new Regex(@"^II?$", RegexOptions.ExplicitCapture);
        public override IEnumerable<ChartOmniboxResult> GetResults(string rawQuery, List<OmniboxToken> tokens, string tokenPattern)
        {
            Match m = regex.Match(tokenPattern);

            if (!m.Success)
                yield break;

            string key = tokens[0].Value;

            var keyMatch = OmniboxUtils.Contains(Keyword, Keyword, key) ?? OmniboxUtils.Contains(Keyword, NiceName(), key);

            if (keyMatch == null)
                yield break;

            if (tokens.Count == 1)
                yield return new ChartOmniboxResult { Distance = keyMatch.Distance, KeywordMatch = keyMatch };

            else
            {
                string pattern = tokens[1].Value;

                bool isPascalCase = OmniboxUtils.IsPascalCasePattern(pattern);

                foreach (var match in OmniboxUtils.Matches(queries, QueryUtils.GetNiceName, pattern, isPascalCase))
                {
                    var queryName = match.Value;
                    if (OmniboxParser.Manager.AllowedQuery(queryName))
                    {
                        yield return new ChartOmniboxResult { Distance = keyMatch.Distance + match.Distance, KeywordMatch = keyMatch, QueryName = queryName, QueryNameMatch = match };
                    }
                }
            }
        }
    }

    public class ChartOmniboxResult : OmniboxResult
    {
        public OmniboxMatch KeywordMatch { get; set; }

        public object QueryName { get; set; }
        public OmniboxMatch QueryNameMatch { get; set; }

        public override string ToString()
        {
            if (QueryName == null)
                return KeywordMatch.Value.ToString();

            return "{0} {1}".Formato(KeywordMatch.Value, OmniboxParser.Manager.CleanQueryName(QueryName));
        }
    }
}
