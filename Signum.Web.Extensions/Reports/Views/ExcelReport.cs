﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using Signum.Utilities;
    using Signum.Entities;
    using Signum.Web;
    using System.Collections;
    using System.Collections.Specialized;
    using System.ComponentModel.DataAnnotations;
    using System.Configuration;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web.Caching;
    using System.Web.DynamicData;
    using System.Web.SessionState;
    using System.Web.Profile;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Xml.Linq;
    using Signum.Engine;
    using Signum.Entities.Reports;
    using Signum.Entities.Basics;
    using Signum.Entities.Files;
    using Signum.Web.Files;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MvcRazorClassGenerator", "1.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Reports/Views/ExcelReport.cshtml")]
    public class _Page_Reports_Views_ExcelReport_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
#line hidden

        public _Page_Reports_Views_ExcelReport_cshtml()
        {
        }
        protected System.Web.HttpApplication ApplicationInstance
        {
            get
            {
                return ((System.Web.HttpApplication)(Context.ApplicationInstance));
            }
        }
        public override void Execute()
        {






 using (var e = Html.TypeContext<ExcelReportDN>())
{
    using (var query = e.SubContext(f => f.Query))
    {
    
Write(Html.HiddenRuntimeInfo(query));

                                  
    
Write(Html.ValueLine(query, f => f.DisplayName, f => { f.ReadOnly = true; f.LabelText = "Query"; }));

                                                                                                  ;
    
Write(Html.Hidden(query.Compose("Key"), query.Value.Key));

                                                       
    
Write(Html.Hidden(query.Compose("DisplayName"), query.Value.DisplayName));

                                                                       
    }

    
Write(Html.ValueLine(e, f => f.DisplayName));

                                          
    
Write(Html.ValueLine(e, f => f.Deleted, vl => vl.ReadOnly = true));

                                                                

    
Write(Html.FileLine(e, f => f.File, fl => fl.AsyncUpload = false));

                                                                
}

        }
    }
}