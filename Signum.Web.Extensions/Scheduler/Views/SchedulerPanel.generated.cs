﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Signum.Web.Extensions.Scheduler.Views
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
    
    #line 3 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
    using Signum.Engine.Scheduler;
    
    #line default
    #line hidden
    using Signum.Entities;
    
    #line 4 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
    using Signum.Entities.DynamicQuery;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
    using Signum.Entities.Scheduler;
    
    #line default
    #line hidden
    using Signum.Utilities;
    
    #line 1 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
    using Signum.Utilities.ExpressionTrees;
    
    #line default
    #line hidden
    using Signum.Web;
    
    #line 2 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
    using Signum.Web.Scheduler;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Scheduler/Views/SchedulerPanel.cshtml")]
    public partial class SchedulerPanel : System.Web.Mvc.WebViewPage<SchedulerState>
    {
        public SchedulerPanel()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div>\r\n    <h2>");

            
            #line 8 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
   Write(ViewData[ViewDataKeys.Title]);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n    <div>\r\n        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 268), Tuple.Create("\"", 325)
            
            #line 10 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
, Tuple.Create(Tuple.Create("", 275), Tuple.Create<System.Object, System.Int32>(Url.Action((SchedulerController sc) => sc.Stop())
            
            #line default
            #line hidden
, 275), false)
);

WriteLiteral(" class=\"sf-button\"");

WriteAttribute("style", Tuple.Create(" style=\"", 344), Tuple.Create("\"", 400)
            
            #line 10 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
                , Tuple.Create(Tuple.Create("", 352), Tuple.Create<System.Object, System.Int32>(Model.Running ? "" : "display:none"
            
            #line default
            #line hidden
, 352), false)
, Tuple.Create(Tuple.Create("", 390), Tuple.Create(";color:red", 390), true)
);

WriteLiteral(" id=\"sfSchedulerDisable\"");

WriteLiteral(">Stop </a>\r\n        <a");

WriteAttribute("href", Tuple.Create(" href=\"", 447), Tuple.Create("\"", 505)
            
            #line 11 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
, Tuple.Create(Tuple.Create("", 454), Tuple.Create<System.Object, System.Int32>(Url.Action((SchedulerController sc) => sc.Start())
            
            #line default
            #line hidden
, 454), false)
);

WriteLiteral(" class=\"sf-button\"");

WriteAttribute("style", Tuple.Create("  style=\"", 524), Tuple.Create("\"", 572)
            
            #line 11 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
                  , Tuple.Create(Tuple.Create("", 533), Tuple.Create<System.Object, System.Int32>(!Model.Running ? "" : "display:none"
            
            #line default
            #line hidden
, 533), false)
);

WriteLiteral(" id=\"sfSchedulerEnable\"");

WriteLiteral(">Start </a>\r\n    </div>\r\n    <script>\r\n        $(function () {\r\n");

WriteLiteral("            ");

            
            #line 15 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
        Write(SchedulerClient.Module["initDashboard"]());

            
            #line default
            #line hidden
WriteLiteral("\r\n        });\r\n    </script>\r\n    <div");

WriteLiteral(" id=\"schedulerMainDiv\"");

WriteLiteral(">\r\n        <br />\r\n        <h2>SchedulerLogic state in ");

            
            #line 20 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
                               Write(Environment.MachineName);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n\r\n        State: <strong>\r\n");

            
            #line 23 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
            
            
            #line default
            #line hidden
            
            #line 23 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
             if (Model.Running)
            {

            
            #line default
            #line hidden
WriteLiteral("                <span");

WriteLiteral(" style=\"color: Green\"");

WriteLiteral(">RUNNING</span>\r\n");

            
            #line 26 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
            }
            else
            {

            
            #line default
            #line hidden
WriteLiteral("                <span");

WriteLiteral(" style=\"color: Red\"");

WriteLiteral(">STOPPED</span>\r\n");

            
            #line 30 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
            }
            
            #line default
            #line hidden
WriteLiteral("</strong>\r\n        <br />\r\n        SchedulerMargin: ");

            
            #line 32 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
                    Write(Model.SchedulerMargin);

            
            #line default
            #line hidden
WriteLiteral("\r\n        <br />\r\n        NextExecution: ");

            
            #line 34 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
                  Write(Model.NextExecution);

            
            #line default
            #line hidden
WriteLiteral("  (");

            
            #line 34 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
                                          Write(Model.NextExecution == null ? "-None-" : Model.NextExecution.Value.ToAgoString());

            
            #line default
            #line hidden
WriteLiteral(")\r\n    <br />\r\n        <h3>In Memory Queue</h3>\r\n        <table");

WriteLiteral(" class=\"sf-search-results sf-stats-table\"");

WriteLiteral(@">
            <thead>
                <tr>
                    <th>ScheduledTask
                    </th>
                    <th>Rule
                    </th>
                    <th>NextExecution
                    </th>
                </tr>
            </thead>
            <tbody>
");

            
            #line 49 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
                
            
            #line default
            #line hidden
            
            #line 49 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
                 foreach (var item in Model.Queue)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <tr>\r\n                        <td>");

            
            #line 52 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
                       Write(Html.LightEntityLine(item.ScheduledTask, true));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </td>\r\n                        <td>");

            
            #line 54 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
                       Write(item.Rule);

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </td>\r\n                        <td>");

            
            #line 56 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
                       Write(item.NextExecution);

            
            #line default
            #line hidden
WriteLiteral(" (");

            
            #line 56 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
                                            Write(item.NextExecution.ToAgoString());

            
            #line default
            #line hidden
WriteLiteral(")\r\n                        </td>\r\n                    </tr>\r\n");

            
            #line 59 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n        <br />\r\n        <h2>");

            
            #line 64 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
       Write(typeof(ScheduledTaskDN).NicePluralName());

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n\r\n");

WriteLiteral("        ");

            
            #line 66 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
   Write(Html.SearchControl(new FindOptions(typeof(ScheduledTaskDN))
{
    ShowFilters = false,
    SearchOnLoad = true,
    Pagination = new Pagination.Firsts(10),
}, new Context(null, "st")));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <br />\r\n        <br />\r\n        <h2>");

            
            #line 74 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
       Write(typeof(ScheduledTaskLogDN).NicePluralName());

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n\r\n");

WriteLiteral("        ");

            
            #line 76 "..\..\Scheduler\Views\SchedulerPanel.cshtml"
   Write(Html.SearchControl(new FindOptions(typeof(ScheduledTaskLogDN))
{
    OrderOptions = { new OrderOption("StartTime", Signum.Entities.DynamicQuery.OrderType.Descending) },
    ShowFilters = false,
    SearchOnLoad = true,
    Pagination = new Pagination.Firsts(10),
}, new Context(null, "stl")));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <br />\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
