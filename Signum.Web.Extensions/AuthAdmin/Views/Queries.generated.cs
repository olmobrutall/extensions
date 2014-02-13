﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Signum.Web.Extensions.AuthAdmin.Views
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Signum.Engine;
    
    #line 2 "..\..\AuthAdmin\Views\Queries.cshtml"
    using Signum.Engine.Authorization;
    
    #line default
    #line hidden
    using Signum.Entities;
    using Signum.Entities.Authorization;
    using Signum.Utilities;
    using Signum.Web;
    using Signum.Web.Auth;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/AuthAdmin/Views/Queries.cshtml")]
    public partial class Queries : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Queries()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\AuthAdmin\Views\Queries.cshtml"
Write(Html.ScriptCss("~/authAdmin/Content/AuthAdmin.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 3 "..\..\AuthAdmin\Views\Queries.cshtml"
 using (var tc = Html.TypeContext<QueryRulePack>())
{
    
            
            #line default
            #line hidden
            
            #line 5 "..\..\AuthAdmin\Views\Queries.cshtml"
Write(Html.EntityLine(tc, f => f.Role));

            
            #line default
            #line hidden
            
            #line 5 "..\..\AuthAdmin\Views\Queries.cshtml"
                                     
    
            
            #line default
            #line hidden
            
            #line 6 "..\..\AuthAdmin\Views\Queries.cshtml"
Write(Html.ValueLine(tc, f => f.Strategy));

            
            #line default
            #line hidden
            
            #line 6 "..\..\AuthAdmin\Views\Queries.cshtml"
                                        
    
            
            #line default
            #line hidden
            
            #line 7 "..\..\AuthAdmin\Views\Queries.cshtml"
Write(Html.EntityLine(tc, f => f.Type));

            
            #line default
            #line hidden
            
            #line 7 "..\..\AuthAdmin\Views\Queries.cshtml"
                                     


            
            #line default
            #line hidden
WriteLiteral("    <table");

WriteLiteral(" class=\"sf-auth-rules\"");

WriteLiteral(" id=\"queries\"");

WriteLiteral(">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 13 "..\..\AuthAdmin\Views\Queries.cshtml"
               Write(typeof(Signum.Entities.Basics.QueryDN).NiceName());

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 16 "..\..\AuthAdmin\Views\Queries.cshtml"
               Write(AuthAdminMessage.Allow.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 19 "..\..\AuthAdmin\Views\Queries.cshtml"
               Write(AuthAdminMessage.Deny.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 22 "..\..\AuthAdmin\Views\Queries.cshtml"
               Write(AuthAdminMessage.Overriden.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n");

            
            #line 26 "..\..\AuthAdmin\Views\Queries.cshtml"
        
            
            #line default
            #line hidden
            
            #line 26 "..\..\AuthAdmin\Views\Queries.cshtml"
         foreach (var item in tc.TypeElementContext(p => p.Rules))
        {

            
            #line default
            #line hidden
WriteLiteral("            <tr>\r\n                <td>\r\n");

WriteLiteral("                    ");

            
            #line 30 "..\..\AuthAdmin\Views\Queries.cshtml"
               Write(Html.Span(null, item.Value.Resource.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 31 "..\..\AuthAdmin\Views\Queries.cshtml"
               Write(Html.Hidden(item.Compose("Resource_Key"), item.Value.Resource.Key));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 32 "..\..\AuthAdmin\Views\Queries.cshtml"
               Write(Html.Hidden(item.Compose("AllowedBase"), item.Value.AllowedBase));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n                <td>\r\n");

            
            #line 35 "..\..\AuthAdmin\Views\Queries.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 35 "..\..\AuthAdmin\Views\Queries.cshtml"
                     if (!item.Value.CoercedValues.Contains(true))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteLiteral(" class=\"sf-auth-chooser sf-auth-allowed\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 38 "..\..\AuthAdmin\Views\Queries.cshtml"
                       Write(Html.RadioButton(item.Compose("Allowed"), "True", item.Value.Allowed));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </a>\r\n");

            
            #line 40 "..\..\AuthAdmin\Views\Queries.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </td>\r\n                <td>\r\n");

            
            #line 43 "..\..\AuthAdmin\Views\Queries.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 43 "..\..\AuthAdmin\Views\Queries.cshtml"
                     if (!item.Value.CoercedValues.Contains(false))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteLiteral(" class=\"sf-auth-chooser sf-auth-not-allowed\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 46 "..\..\AuthAdmin\Views\Queries.cshtml"
                       Write(Html.RadioButton(item.Compose("Allowed"), "False", !item.Value.Allowed));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </a> \r\n");

            
            #line 48 "..\..\AuthAdmin\Views\Queries.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </td>\r\n                <td>\r\n");

WriteLiteral("                    ");

            
            #line 51 "..\..\AuthAdmin\Views\Queries.cshtml"
               Write(Html.CheckBox(item.Compose("Overriden"), item.Value.Overriden, new { disabled = "disabled", @class = "sf-auth-overriden" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");

            
            #line 54 "..\..\AuthAdmin\Views\Queries.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </table>\r\n");

            
            #line 56 "..\..\AuthAdmin\Views\Queries.cshtml"
}
            
            #line default
            #line hidden
WriteLiteral(" ");

        }
    }
}
#pragma warning restore 1591
