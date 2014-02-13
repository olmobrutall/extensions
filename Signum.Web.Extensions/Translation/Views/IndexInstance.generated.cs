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

namespace Signum.Web.Extensions.Translation.Views
{
    using System;
    using System.Collections.Generic;
    
    #line 4 "..\..\Translation\Views\IndexInstance.cshtml"
    using System.Globalization;
    
    #line default
    #line hidden
    using System.IO;
    using System.Linq;
    using System.Net;
    
    #line 1 "..\..\Translation\Views\IndexInstance.cshtml"
    using System.Reflection;
    
    #line default
    #line hidden
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
    
    #line 5 "..\..\Translation\Views\IndexInstance.cshtml"
    using Signum.Engine.Basics;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Translation\Views\IndexInstance.cshtml"
    using Signum.Engine.Translation;
    
    #line default
    #line hidden
    using Signum.Entities;
    
    #line 6 "..\..\Translation\Views\IndexInstance.cshtml"
    using Signum.Entities.Translation;
    
    #line default
    #line hidden
    using Signum.Utilities;
    using Signum.Web;
    
    #line 3 "..\..\Translation\Views\IndexInstance.cshtml"
    using Signum.Web.Translation.Controllers;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Translation/Views/IndexInstance.cshtml")]
    public partial class IndexInstance : System.Web.Mvc.WebViewPage<Dictionary<Type, Dictionary<CultureInfo, TranslatedTypeSummary>>>
    {
        public IndexInstance()
        {
        }
        public override void Execute()
        {
            
            #line 8 "..\..\Translation\Views\IndexInstance.cshtml"
  
    ViewBag.Title = TranslationMessage.InstanceTranslations.NiceToString();        

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 12 "..\..\Translation\Views\IndexInstance.cshtml"
Write(Html.ScriptCss("~/Translation/Content/Translation.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 14 "..\..\Translation\Views\IndexInstance.cshtml"
 if (Model.IsEmpty())
{

            
            #line default
            #line hidden
WriteLiteral("    <h2>");

            
            #line 16 "..\..\Translation\Views\IndexInstance.cshtml"
   Write(TranslationMessage.NothingToTranslate.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("</h2>   \r\n");

            
            #line 17 "..\..\Translation\Views\IndexInstance.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <h2>");

            
            #line 20 "..\..\Translation\Views\IndexInstance.cshtml"
   Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n");

            
            #line 21 "..\..\Translation\Views\IndexInstance.cshtml"
    
    var langs = Model.First().Value.Keys;


            
            #line default
            #line hidden
WriteLiteral("    <table");

WriteLiteral(" class=\"st\"");

WriteLiteral(">\r\n        <tr>\r\n            <th></th>\r\n            <th>");

            
            #line 27 "..\..\Translation\Views\IndexInstance.cshtml"
           Write(TranslationMessage.All.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n");

            
            #line 28 "..\..\Translation\Views\IndexInstance.cshtml"
            
            
            #line default
            #line hidden
            
            #line 28 "..\..\Translation\Views\IndexInstance.cshtml"
             foreach (var ci in langs)
            {

            
            #line default
            #line hidden
WriteLiteral("                <th>");

            
            #line 30 "..\..\Translation\Views\IndexInstance.cshtml"
               Write(ci.Name);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n");

            
            #line 31 "..\..\Translation\Views\IndexInstance.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </tr>\r\n");

            
            #line 33 "..\..\Translation\Views\IndexInstance.cshtml"
        
            
            #line default
            #line hidden
            
            #line 33 "..\..\Translation\Views\IndexInstance.cshtml"
         foreach (var type in Model)
        {

            
            #line default
            #line hidden
WriteLiteral("            <tr>\r\n                <th>");

            
            #line 36 "..\..\Translation\Views\IndexInstance.cshtml"
               Write(type.Key.NiceName());

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n\r\n                <td>\r\n");

WriteLiteral("                    ");

            
            #line 39 "..\..\Translation\Views\IndexInstance.cshtml"
               Write(Html.ActionLink(TranslationMessage.View.NiceToString(), (TranslatedInstanceController tc) => tc.View(TypeLogic.GetCleanName(type.Key), null)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </td>\r\n");

            
            #line 41 "..\..\Translation\Views\IndexInstance.cshtml"
                
            
            #line default
            #line hidden
            
            #line 41 "..\..\Translation\Views\IndexInstance.cshtml"
                 foreach (var tf in type.Value.Values)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <td>\r\n");

            
            #line 44 "..\..\Translation\Views\IndexInstance.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 44 "..\..\Translation\Views\IndexInstance.cshtml"
                         if (tf.CultureInfo.Name == TranslatedInstanceLogic.DefaultCulture)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            ");

            
            #line 46 "..\..\Translation\Views\IndexInstance.cshtml"
                             Write(TranslationMessage.None.NiceToString());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 47 "..\..\Translation\Views\IndexInstance.cshtml"
                        }
                        else
                        {
                            
            
            #line default
            #line hidden
            
            #line 50 "..\..\Translation\Views\IndexInstance.cshtml"
                       Write(Html.ActionLink(TranslationMessage.View.NiceToString(), (TranslatedInstanceController tc) => tc.View(TypeLogic.GetCleanName(tf.Type), tf.CultureInfo.Name)));

            
            #line default
            #line hidden
            
            #line 50 "..\..\Translation\Views\IndexInstance.cshtml"
                                                                                                                                                                                        

            
            #line default
            #line hidden
WriteLiteral("                            <br />\r\n");

            
            #line 52 "..\..\Translation\Views\IndexInstance.cshtml"
                            if (tf.CultureInfo.IsNeutralCulture)
                            {
                                
            
            #line default
            #line hidden
            
            #line 54 "..\..\Translation\Views\IndexInstance.cshtml"
                           Write(Html.ActionLink(TranslationMessage.Sync.NiceToString(), (TranslatedInstanceController tc) => tc.Sync(TypeLogic.GetCleanName(tf.Type), tf.CultureInfo.Name), new { @class = "status-" + tf.State.ToString() }));

            
            #line default
            #line hidden
            
            #line 54 "..\..\Translation\Views\IndexInstance.cshtml"
                                                                                                                                                                                                                                              
                            }
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </td>\r\n");

            
            #line 58 "..\..\Translation\Views\IndexInstance.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </tr>\r\n");

            
            #line 60 "..\..\Translation\Views\IndexInstance.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </table>\r\n");

            
            #line 62 "..\..\Translation\Views\IndexInstance.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
