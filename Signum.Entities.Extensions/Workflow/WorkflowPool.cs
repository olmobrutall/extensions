﻿using Signum.Entities;
using Signum.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Entities.Workflow
{
    [Serializable, EntityKind(EntityKind.String, EntityData.Master)]
    public class WorkflowPoolEntity : Entity, IWorkflowObjectEntity, IWithModel
    {
        [NotNullable]
        [NotNullValidator]
        public WorkflowEntity Workflow { get; set; }

        [NotNullable, SqlDbType(Size = 100)]
        [StringLengthValidator(AllowNulls = false, Min = 3, Max = 100)]
        public string Name { get; set; }

        [NotNullable, SqlDbType(Size = 100)]
        [StringLengthValidator(AllowNulls = false, Min = 1, Max = 100)]
        public string BpmnElementId { get; set; }

        [NotNullable]
        [NotNullValidator]
        public WorkflowXmlEntity Xml { get; set; }

        static Expression<Func<WorkflowPoolEntity, string>> ToStringExpression = @this => @this.Name ?? @this.BpmnElementId;
        [ExpressionField]
        public override string ToString()
        {
            return ToStringExpression.Evaluate(this);
        }

        public ModelEntity GetModel()
        {
            var model = new WorkflowPoolModel();
            model.Name = this.Name;
            return model;
        }

        public void SetModel(ModelEntity model)
        {
            var wModel = (WorkflowPoolModel)model;
            this.Name = wModel.Name;
        }
    }

    [AutoInit]
    public static class WorkflowPoolOperation
    {
        public static readonly ExecuteSymbol<WorkflowPoolEntity> Save;
        public static readonly DeleteSymbol<WorkflowPoolEntity> Delete;
    }

    [Serializable]
    public class WorkflowPoolModel : ModelEntity
    {
        [NotNullable, SqlDbType(Size = 100)]
        [StringLengthValidator(AllowNulls = false, Min = 3, Max = 100)]
        public string Name { get; set; }
    }
}
