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

namespace Signum.Web.Extensions.Chart.Views
{
    using System;
    using System.Collections.Generic;
    
    #line 4 "..\..\Chart\Views\UserChart.cshtml"
    using System.Configuration;
    
    #line default
    #line hidden
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
    
    #line 9 "..\..\Chart\Views\UserChart.cshtml"
    using Signum.Engine.Basics;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Chart\Views\UserChart.cshtml"
    using Signum.Engine.DynamicQuery;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Chart\Views\UserChart.cshtml"
    using Signum.Entities;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Chart\Views\UserChart.cshtml"
    using Signum.Entities.Chart;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Chart\Views\UserChart.cshtml"
    using Signum.Entities.DynamicQuery;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Chart\Views\UserChart.cshtml"
    using Signum.Entities.Reflection;
    
    #line default
    #line hidden
    
    #line 10 "..\..\Chart\Views\UserChart.cshtml"
    using Signum.Entities.UserQueries;
    
    #line default
    #line hidden
    using Signum.Utilities;
    
    #line 1 "..\..\Chart\Views\UserChart.cshtml"
    using Signum.Web;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Chart\Views\UserChart.cshtml"
    using Signum.Web.Chart;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Chart/Views/UserChart.cshtml")]
    public partial class UserChart : System.Web.Mvc.WebViewPage<dynamic>
    {
        public UserChart()
        {
        }
        public override void Execute()
        {
            
            #line 11 "..\..\Chart\Views\UserChart.cshtml"
Write(Html.ScriptCss("~/Chart/Content/Chart.css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n<style");

WriteLiteral(" type=\"text/css\"");

WriteLiteral(">\r\n    .sf-chart-control .sf-repeater-element\r\n    {\r\n        padding: 2px 10px;\r" +
"\n    }\r\n\r\n        .sf-chart-control .sf-repeater-element legend\r\n        {\r\n    " +
"        float: left;\r\n            margin-right: 10px;\r\n        }\r\n</style>\r\n<div" +
"");

WriteLiteral(" class=\"sf-chart-control\"");

WriteLiteral(" \r\n    data-subtokens-url=\"");

            
            #line 25 "..\..\Chart\Views\UserChart.cshtml"
                   Write(Url.Action("NewSubTokensCombo", "Chart"));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" \r\n    data-add-filter-url=\"");

            
            #line 26 "..\..\Chart\Views\UserChart.cshtml"
                    Write(Url.Action("AddFilter", "Chart"));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" \r\n    data-prefix=\"");

            
            #line 27 "..\..\Chart\Views\UserChart.cshtml"
            Write(Model.ControlID);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n");

            
            #line 28 "..\..\Chart\Views\UserChart.cshtml"
    
            
            #line default
            #line hidden
            
            #line 28 "..\..\Chart\Views\UserChart.cshtml"
     using (var uc = Html.TypeContext<UserChartDN>())
    {

        object queryName = QueryLogic.ToQueryName(uc.Value.Query.Key);

        QueryDescription queryDescription = (QueryDescription)ViewData[ViewDataKeys.QueryDescription];
        if (queryDescription == null)
        {
            queryDescription = DynamicQueryManager.Current.QueryDescription(queryName);
            ViewData[ViewDataKeys.QueryDescription] = queryDescription;
        }
        
        
            
            #line default
            #line hidden
            
            #line 40 "..\..\Chart\Views\UserChart.cshtml"
   Write(Html.Hidden("webQueryName", Navigator.ResolveWebQueryName(queryName)));

            
            #line default
            #line hidden
            
            #line 40 "..\..\Chart\Views\UserChart.cshtml"
                                                                              

        using (var query = uc.SubContext(tc => tc.Query))
        {
        
            
            #line default
            #line hidden
            
            #line 44 "..\..\Chart\Views\UserChart.cshtml"
   Write(Html.HiddenRuntimeInfo(query));

            
            #line default
            #line hidden
            
            #line 44 "..\..\Chart\Views\UserChart.cshtml"
                                      
        
        
            
            #line default
            #line hidden
            
            #line 46 "..\..\Chart\Views\UserChart.cshtml"
   Write(Html.Hidden(query.Compose("Key"), query.Value.Key));

            
            #line default
            #line hidden
            
            #line 46 "..\..\Chart\Views\UserChart.cshtml"
                                                           
        
            
            #line default
            #line hidden
            
            #line 47 "..\..\Chart\Views\UserChart.cshtml"
   Write(Html.Hidden(query.Compose("Name"), query.Value.Name));

            
            #line default
            #line hidden
            
            #line 47 "..\..\Chart\Views\UserChart.cshtml"
                                                             

        
            
            #line default
            #line hidden
            
            #line 49 "..\..\Chart\Views\UserChart.cshtml"
   Write(Html.Field("Query", Navigator.IsFindable(queryName) ?
                new HtmlTag("a").Class("sf-value-line").Attr("href", Navigator.FindRoute(queryName)).InnerHtml(query.Value.Name.EncodeHtml()).ToHtml() :
                Html.Span("spanQuery", query.Value.Name, "sf-value-line")));

            
            #line default
            #line hidden
            
            #line 51 "..\..\Chart\Views\UserChart.cshtml"
                                                                          


            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"clearall\"");

WriteLiteral(">\r\n        </div>\r\n");

            
            #line 55 "..\..\Chart\Views\UserChart.cshtml"
        }
    
        
            
            #line default
            #line hidden
            
            #line 57 "..\..\Chart\Views\UserChart.cshtml"
   Write(Html.EntityLine(uc, tc => tc.Related, el => el.Create = false));

            
            #line default
            #line hidden
            
            #line 57 "..\..\Chart\Views\UserChart.cshtml"
                                                                       
        
            
            #line default
            #line hidden
            
            #line 58 "..\..\Chart\Views\UserChart.cshtml"
   Write(Html.ValueLine(uc, tc => tc.DisplayName));

            
            #line default
            #line hidden
            
            #line 58 "..\..\Chart\Views\UserChart.cshtml"
                                                 
        
        var entityTypePrefix = uc.SubContext(a => a.EntityType).ControlID;
        
        
            
            #line default
            #line hidden
            
            #line 62 "..\..\Chart\Views\UserChart.cshtml"
   Write(Html.EntityLine(uc, f => f.EntityType, el => { 
       el.AutocompleteUrl = Url.Action("TypeAutocomplete", "Finder");
       el.AttachFunction = new JsLineFunction(ChartClient.Module, "attachShowCurrentEntity"); 
   }));

            
            #line default
            #line hidden
            
            #line 65 "..\..\Chart\Views\UserChart.cshtml"
     

            
            #line default
            #line hidden
WriteLiteral("        <p");

WriteLiteral(" class=\"messageEntity\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 67 "..\..\Chart\Views\UserChart.cshtml"
       Write(UserQueryMessage.Use0ToFilterCurrentEntity.NiceToString().Formato(CurrentEntityConverter.CurrentEntityKey));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </p>\r\n");

            
            #line 69 "..\..\Chart\Views\UserChart.cshtml"

        
            
            #line default
            #line hidden
            
            #line 70 "..\..\Chart\Views\UserChart.cshtml"
   Write(Html.EntityRepeater(uc, tc => tc.Filters, er => { er.PreserveViewData = true; er.PartialViewName = "~/Chart/Views/UserChartFilter.cshtml"; }));

            
            #line default
            #line hidden
            
            #line 70 "..\..\Chart\Views\UserChart.cshtml"
                                                                                                                                                      

        
            
            #line default
            #line hidden
            
            #line 72 "..\..\Chart\Views\UserChart.cshtml"
   Write(Html.EntityRepeater(uc, tc => tc.Orders, er => { er.PreserveViewData = true; er.PartialViewName = "~/Chart/Views/UserChartOrder.cshtml"; }));

            
            #line default
            #line hidden
            
            #line 72 "..\..\Chart\Views\UserChart.cshtml"
                                                                                                                                                    


            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteAttribute("id", Tuple.Create(" id=\"", 2910), Tuple.Create("\"", 2953)
            
            #line 74 "..\..\Chart\Views\UserChart.cshtml"
, Tuple.Create(Tuple.Create("", 2915), Tuple.Create<System.Object, System.Int32>(uc.Compose("sfChartBuilderContainer")
            
            #line default
            #line hidden
, 2915), false)
);

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 75 "..\..\Chart\Views\UserChart.cshtml"
       Write(Html.Partial(ChartClient.ChartBuilderView, uc.Value));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");

            
            #line 77 "..\..\Chart\Views\UserChart.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

        }
    }
}
#pragma warning restore 1591
