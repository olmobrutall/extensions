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

namespace Signum.Web.Extensions.SMS.Views
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
    
    #line 1 "..\..\SMS\Views\SMSTemplate.cshtml"
    using Signum.Engine;
    
    #line default
    #line hidden
    
    #line 6 "..\..\SMS\Views\SMSTemplate.cshtml"
    using Signum.Engine.SMS;
    
    #line default
    #line hidden
    
    #line 3 "..\..\SMS\Views\SMSTemplate.cshtml"
    using Signum.Entities;
    
    #line default
    #line hidden
    
    #line 2 "..\..\SMS\Views\SMSTemplate.cshtml"
    using Signum.Entities.SMS;
    
    #line default
    #line hidden
    
    #line 7 "..\..\SMS\Views\SMSTemplate.cshtml"
    using Signum.Utilities;
    
    #line default
    #line hidden
    
    #line 4 "..\..\SMS\Views\SMSTemplate.cshtml"
    using Signum.Web;
    
    #line default
    #line hidden
    
    #line 8 "..\..\SMS\Views\SMSTemplate.cshtml"
    using Signum.Web.Mailing;
    
    #line default
    #line hidden
    
    #line 5 "..\..\SMS\Views\SMSTemplate.cshtml"
    using Signum.Web.SMS;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/SMS/Views/SMSTemplate.cshtml")]
    public partial class SMSTemplate : System.Web.Mvc.WebViewPage<dynamic>
    {
        public SMSTemplate()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n\r\n");

            
            #line 11 "..\..\SMS\Views\SMSTemplate.cshtml"
Write(Html.ScriptCss("~/SMS/Content/SMS.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 13 "..\..\SMS\Views\SMSTemplate.cshtml"
 using (var tc = Html.TypeContext<SMSTemplateDN>())
{   
    
            
            #line default
            #line hidden
            
            #line 15 "..\..\SMS\Views\SMSTemplate.cshtml"
Write(Html.ValueLine(tc, s => s.Name));

            
            #line default
            #line hidden
            
            #line 15 "..\..\SMS\Views\SMSTemplate.cshtml"
                                    
    
            
            #line default
            #line hidden
            
            #line 16 "..\..\SMS\Views\SMSTemplate.cshtml"
Write(Html.ValueLine(tc, s => s.Active, vl => vl.ReadOnly = true));

            
            #line default
            #line hidden
            
            #line 16 "..\..\SMS\Views\SMSTemplate.cshtml"
                                                                
    
            
            #line default
            #line hidden
            
            #line 17 "..\..\SMS\Views\SMSTemplate.cshtml"
Write(Html.ValueLine(tc, s => s.StartDate));

            
            #line default
            #line hidden
            
            #line 17 "..\..\SMS\Views\SMSTemplate.cshtml"
                                         
    
            
            #line default
            #line hidden
            
            #line 18 "..\..\SMS\Views\SMSTemplate.cshtml"
Write(Html.ValueLine(tc, s => s.EndDate));

            
            #line default
            #line hidden
            
            #line 18 "..\..\SMS\Views\SMSTemplate.cshtml"
                                        
    
    
            
            #line default
            #line hidden
            
            #line 20 "..\..\SMS\Views\SMSTemplate.cshtml"
Write(Html.ValueLine(tc, s => s.From));

            
            #line default
            #line hidden
            
            #line 20 "..\..\SMS\Views\SMSTemplate.cshtml"
                                     
    
            
            #line default
            #line hidden
            
            #line 21 "..\..\SMS\Views\SMSTemplate.cshtml"
Write(Html.ValueLine(tc, s => s.Certified));

            
            #line default
            #line hidden
            
            #line 21 "..\..\SMS\Views\SMSTemplate.cshtml"
                                         
    
            
            #line default
            #line hidden
            
            #line 22 "..\..\SMS\Views\SMSTemplate.cshtml"
Write(Html.ValueLine(tc, s => s.EditableMessage));

            
            #line default
            #line hidden
            
            #line 22 "..\..\SMS\Views\SMSTemplate.cshtml"
                                               
    
    
            
            #line default
            #line hidden
            
            #line 24 "..\..\SMS\Views\SMSTemplate.cshtml"
Write(Html.ValueLine(tc, s => s.RemoveNoSMSCharacters));

            
            #line default
            #line hidden
            
            #line 24 "..\..\SMS\Views\SMSTemplate.cshtml"
                                                     
    
            
            #line default
            #line hidden
            
            #line 25 "..\..\SMS\Views\SMSTemplate.cshtml"
Write(Html.ValueLine(tc, s => s.MessageLengthExceeded));

            
            #line default
            #line hidden
            
            #line 25 "..\..\SMS\Views\SMSTemplate.cshtml"
                                                     
    

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"clearall\"");

WriteLiteral("></div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" id=\"sfTemplateLiterals\"");

WriteLiteral(">\r\n");

            
            #line 29 "..\..\SMS\Views\SMSTemplate.cshtml"
        
            
            #line default
            #line hidden
            
            #line 29 "..\..\SMS\Views\SMSTemplate.cshtml"
         using (Html.FieldInline())
        {
            
            
            #line default
            #line hidden
            
            #line 31 "..\..\SMS\Views\SMSTemplate.cshtml"
       Write(Html.EntityCombo(tc, s => s.AssociatedType, ec =>
            {
                ec.Data = SMSLogic.RegisteredDataObjectProviders();
                ec.ComboHtmlProperties["class"] = "sf-associated-type";
                ec.ComboHtmlProperties["data-url"] = Url.Action<SMSController>(s => s.GetLiteralsForType(ec.ControlID));
                ec.ComboHtmlProperties["data-control-id"] = ec.ControlID;
                ec.AttachFunction = new JsLineFunction(SMSClient.Module, "attachAssociatedType");
            }));

            
            #line default
            #line hidden
            
            #line 38 "..\..\SMS\Views\SMSTemplate.cshtml"
              
        }

            
            #line default
            #line hidden
WriteLiteral("        ");

            
            #line 40 "..\..\SMS\Views\SMSTemplate.cshtml"
    Write(new HtmlTag("select").Attr("multiple", "multiple").Id("sfLiterals").ToHtml());

            
            #line default
            #line hidden
WriteLiteral("\r\n        <br />\r\n        <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"sf-button\"");

WriteLiteral(" id=\"sfInsertLiteral\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1582), Tuple.Create("\"", 1623)
            
            #line 42 "..\..\SMS\Views\SMSTemplate.cshtml"
, Tuple.Create(Tuple.Create("", 1590), Tuple.Create<System.Object, System.Int32>(SmsMessage.Insert.NiceToString()
            
            #line default
            #line hidden
, 1590), false)
);

WriteLiteral(" />\r\n    </div>\r\n");

            
            #line 44 "..\..\SMS\Views\SMSTemplate.cshtml"
    

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"sf-tabs-repeater sf-sms-template-messages\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 46 "..\..\SMS\Views\SMSTemplate.cshtml"
   Write(Html.EntityRepeater(tc, e => e.Messages, er =>
        {
            er.AttachFunction = new JsLineFunction(MailingClient.TabsRepeaterModule, "attachTabRepeater");
            er.PreserveViewData = true;
        }));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n");

            
            #line 52 "..\..\SMS\Views\SMSTemplate.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
