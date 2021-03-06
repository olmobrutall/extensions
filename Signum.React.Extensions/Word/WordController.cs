﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Signum.Engine.Authorization;
using Signum.Entities;
using Signum.Entities.Authorization;
using Signum.Services;
using Signum.Utilities;
using Signum.React.Facades;
using Signum.React.Authorization;
using Signum.Engine.Cache;
using Signum.Engine;
using Signum.Entities.Cache;
using Signum.Utilities.ExpressionTrees;
using Signum.Entities.Processes;
using Signum.Engine.Processes;
using System.Threading;
using Signum.React.ApiControllers;
using Signum.Engine.Basics;
using Signum.Entities.Word;
using Signum.Engine.Word;
using System.Web;
using Signum.React.Files;
using System.IO;

namespace Signum.React.Word
{
    public class WordController : ApiController
    {
        [Route("api/word/createReport"), HttpPost]
        public HttpResponseMessage View(CreateWordReportRequest request)
        {
            var template = request.template.Retrieve();
            var entity = request.entity.Retrieve();

            ISystemWordTemplate systemWordReport = template.SystemWordTemplate == null ? null :
                (ISystemWordTemplate)SystemWordTemplateLogic.GetEntityConstructor(template.SystemWordTemplate.ToType()).Invoke(new[] { entity });

            var bytes = request.template.CreateReport(entity, systemWordReport);

            return FilesController.GetHttpReponseMessage(new MemoryStream(bytes), template.FileName);            
        }

        public class CreateWordReportRequest
        {
            public Lite<WordTemplateEntity> template { get; set; }
            public Lite<Entity> entity { get; set; }
        }
    }
}