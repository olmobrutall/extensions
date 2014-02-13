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

namespace Signum.Web.Extensions.Mailing.Views
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
    
    #line 4 "..\..\Mailing\Views\Newsletter.cshtml"
    using Signum.Engine.Basics;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Mailing\Views\Newsletter.cshtml"
    using Signum.Engine.DynamicQuery;
    
    #line default
    #line hidden
    using Signum.Entities;
    
    #line 1 "..\..\Mailing\Views\Newsletter.cshtml"
    using Signum.Entities.Mailing;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Mailing\Views\Newsletter.cshtml"
    using Signum.Entities.Reflection;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    #line 5 "..\..\Mailing\Views\Newsletter.cshtml"
    using Signum.Web.Mailing;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Mailing/Views/Newsletter.cshtml")]
    public partial class Newsletter : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Newsletter()
        {
        }
        public override void Execute()
        {
            
            #line 6 "..\..\Mailing\Views\Newsletter.cshtml"
Write(Html.ScriptCss("~/Mailing/Content/Mailing.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 7 "..\..\Mailing\Views\Newsletter.cshtml"
 using (var nc = Html.TypeContext<NewsletterDN>())
{  

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteAttribute("class", Tuple.Create(" class=\"", 273), Tuple.Create("\"", 315)
            
            #line 9 "..\..\Mailing\Views\Newsletter.cshtml"
, Tuple.Create(Tuple.Create("", 281), Tuple.Create<System.Object, System.Int32>(nc.Value.IsNew ? "" : "sf-tabs"
            
            #line default
            #line hidden
, 281), false)
);

WriteLiteral(">\r\n        <fieldset");

WriteLiteral(" id=\"emTabMain\"");

WriteLiteral(">\r\n            <legend>Newsletter</legend>\r\n");

WriteLiteral("            ");

            
            #line 12 "..\..\Mailing\Views\Newsletter.cshtml"
       Write(Html.ValueLine(nc, n => n.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 13 "..\..\Mailing\Views\Newsletter.cshtml"
       Write(Html.ValueLine(nc, n => n.State, vl => vl.ReadOnly = true));

            
            #line default
            #line hidden
WriteLiteral("     \r\n            \r\n");

WriteLiteral("            ");

            
            #line 15 "..\..\Mailing\Views\Newsletter.cshtml"
       Write(Html.EntityCombo(nc, n => n.SmtpConfig));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 16 "..\..\Mailing\Views\Newsletter.cshtml"
       Write(Html.ValueLine(nc, n => n.From));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("            ");

            
            #line 17 "..\..\Mailing\Views\Newsletter.cshtml"
       Write(Html.ValueLine(nc, n => n.DisplayFrom));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Mailing\Views\Newsletter.cshtml"
       Write(Html.EntityLine(nc, e => e.Query));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 21 "..\..\Mailing\Views\Newsletter.cshtml"
            
            
            #line default
            #line hidden
            
            #line 21 "..\..\Mailing\Views\Newsletter.cshtml"
             if (nc.Value.State == NewsletterState.Sent)
            {
                
            
            #line default
            #line hidden
            
            #line 23 "..\..\Mailing\Views\Newsletter.cshtml"
           Write(Html.ValueLine(nc, n => n.Subject, vl => vl.ReadOnly = true));

            
            #line default
            #line hidden
            
            #line 23 "..\..\Mailing\Views\Newsletter.cshtml"
                                                                             

            
            #line default
            #line hidden
WriteLiteral("                <fieldset>\r\n                    <legend>Message</legend>\r\n       " +
"             <div");

WriteLiteral(" class=\"sf-email-htmlbody\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 27 "..\..\Mailing\Views\Newsletter.cshtml"
                   Write(Html.Raw(nc.Value.Text));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </fieldset>\r\n");

            
            #line 30 "..\..\Mailing\Views\Newsletter.cshtml"
            }
            else if (nc.Value.IsNew)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" style=\"display:none\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 34 "..\..\Mailing\Views\Newsletter.cshtml"
               Write(Html.ValueLine(nc, e => e.Subject));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 35 "..\..\Mailing\Views\Newsletter.cshtml"
               Write(Html.ValueLine(nc, e => e.Text, vl => vl.ValueLineType = ValueLineType.TextArea));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n");

            
            #line 37 "..\..\Mailing\Views\Newsletter.cshtml"
            }
            else
            {
                object queryName = QueryLogic.ToQueryName(nc.Value.Query.Key);
                var queryDescription = DynamicQueryManager.Current.QueryDescription(queryName); //To be use inside query token controls
                    

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"sf-email-replacements-container\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"sf-template-message-insert-container\"");

WriteLiteral(">\r\n                        <fieldset");

WriteLiteral(" class=\"sf-email-replacements-panel\"");

WriteLiteral(">\r\n                            <legend>Replacements</legend>\r\n");

WriteLiteral("                            ");

            
            #line 47 "..\..\Mailing\Views\Newsletter.cshtml"
                       Write(Html.QueryTokenBuilder(null, nc, MailingClient.GetQueryTokenBuilderSettings(queryDescription)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"sf-button sf-email-inserttoken sf-email-inserttoken-basic sf-disabled\"");

WriteLiteral(" data-prefix=\"");

            
            #line 48 "..\..\Mailing\Views\Newsletter.cshtml"
                                                                                                                                       Write(nc.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2252), Tuple.Create("\"", 2309)
            
            #line 48 "..\..\Mailing\Views\Newsletter.cshtml"
                                                                                   , Tuple.Create(Tuple.Create("", 2260), Tuple.Create<System.Object, System.Int32>(EmailTemplateViewMessage.Insert.NiceToString()
            
            #line default
            #line hidden
, 2260), false)
);

WriteLiteral(" />\r\n                            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"sf-button sf-email-inserttoken sf-email-inserttoken-if sf-disabled\"");

WriteLiteral(" data-prefix=\"");

            
            #line 49 "..\..\Mailing\Views\Newsletter.cshtml"
                                                                                                                                    Write(nc.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" data-block=\"if\"");

WriteLiteral(" value=\"if\"");

WriteLiteral(" />\r\n                            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"sf-button sf-email-inserttoken sf-email-inserttoken-foreach sf-disabled\"");

WriteLiteral(" data-prefix=\"");

            
            #line 50 "..\..\Mailing\Views\Newsletter.cshtml"
                                                                                                                                         Write(nc.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" data-block=\"foreach\"");

WriteLiteral(" value=\"foreach\"");

WriteLiteral(" />\r\n                            <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"sf-button sf-email-inserttoken sf-email-inserttoken-any sf-disabled\"");

WriteLiteral(" data-prefix=\"");

            
            #line 51 "..\..\Mailing\Views\Newsletter.cshtml"
                                                                                                                                     Write(nc.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" data-block=\"any\"");

WriteLiteral(" value=\"any\"");

WriteLiteral(" />\r\n                        </fieldset>\r\n                    </div>\r\n");

WriteLiteral("                    ");

            
            #line 54 "..\..\Mailing\Views\Newsletter.cshtml"
               Write(Html.ValueLine(nc, e => e.Subject, vl => vl.ValueHtmlProps["class"] = "sf-email-inserttoken-target"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 55 "..\..\Mailing\Views\Newsletter.cshtml"
               Write(Html.ValueLine(nc, e => e.Text, vl =>
                    {
                        vl.ValueLineType = ValueLineType.TextArea;
                        vl.ValueHtmlProps["style"] = "width:100%; height:180px;";
                        vl.ValueHtmlProps["class"] = "sf-rich-text-editor";
                    }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <script>\r\n                        $(function () {\r\n");

WriteLiteral("                            ");

            
            #line 63 "..\..\Mailing\Views\Newsletter.cshtml"
                        Write(new JsFunction(MailingClient.Module, "initHtmlEditorWithTokens", nc.SubContext(e => e.Text).ControlID));

            
            #line default
            #line hidden
WriteLiteral(";\r\n                        });\r\n                    </script>\r\n                </" +
"div>\r\n");

            
            #line 67 "..\..\Mailing\Views\Newsletter.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </fieldset>\r\n");

            
            #line 69 "..\..\Mailing\Views\Newsletter.cshtml"
        
            
            #line default
            #line hidden
            
            #line 69 "..\..\Mailing\Views\Newsletter.cshtml"
         if (!nc.Value.IsNew)
        {

            
            #line default
            #line hidden
WriteLiteral("            <fieldset");

WriteLiteral(" id=\"emTabSend\"");

WriteLiteral(">\r\n                <legend>Deliveries</legend>\r\n                <fieldset>\r\n     " +
"               <legend>Email recipients</legend>\r\n");

WriteLiteral("                    ");

            
            #line 75 "..\..\Mailing\Views\Newsletter.cshtml"
               Write(Html.SearchControl(new FindOptions(typeof(NewsletterDeliveryDN))
               {
                   FilterOptions = { new FilterOption("Newsletter", nc.Value) { Frozen = true } },
                   SearchOnLoad = true,
               }, new Context(nc, "ncSent")));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </fieldset>\r\n            </fieldset>\r\n");

            
            #line 82 "..\..\Mailing\Views\Newsletter.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>    \r\n");

            
            #line 84 "..\..\Mailing\Views\Newsletter.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("<script>\r\n    $(function () {\r\n");

WriteLiteral("        ");

            
            #line 87 "..\..\Mailing\Views\Newsletter.cshtml"
    Write(new JsFunction(MailingClient.Module, "initReplacements"));

            
            #line default
            #line hidden
WriteLiteral(";\r\n    });\r\n</script>");

        }
    }
}
#pragma warning restore 1591
