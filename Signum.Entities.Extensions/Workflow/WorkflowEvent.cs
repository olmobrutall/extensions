﻿using Signum.Entities;
using Signum.Entities.Basics;
using Signum.Entities.Dynamic;
using Signum.Entities.Scheduler;
using Signum.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace Signum.Entities.Workflow
{
    [Serializable, EntityKind(EntityKind.String, EntityData.Master)]
    public class WorkflowEventEntity : Entity, IWorkflowNodeEntity, IWithModel
    {
        [SqlDbType(Size = 100)]
        [StringLengthValidator(AllowNulls = true, Min = 3, Max = 100)]
        public string Name { get; set; }

        [NotNullable, SqlDbType(Size = 100)]
        [StringLengthValidator(AllowNulls = false, Min = 1, Max = 100)]
        public string BpmnElementId { get; set; }

        [NotNullable]
        [NotNullValidator]
        public WorkflowLaneEntity Lane { get; set; }

        
        public WorkflowEventType Type { get; set; }


        [NotNullable]
        [NotNullValidator]
        public WorkflowXmlEntity Xml { get; set; }

        static Expression<Func<WorkflowEventEntity, string>> ToStringExpression = @this => @this.Name ?? @this.BpmnElementId;
        [ExpressionField]
        public override string ToString()
        {
            return ToStringExpression.Evaluate(this);
        }

        public ModelEntity GetModel()
        {
            var model = new WorkflowEventModel();
            model.MainEntityType = this.Lane.Pool.Workflow.MainEntityType;
            model.Name = this.Name;
            model.Type = this.Type;
            model.Task = WorkflowEventTaskModel.GetModel(this);
            return model;
        }

        public void SetModel(ModelEntity model)
        {
            var wModel = (WorkflowEventModel)model;
            this.Name = wModel.Name;
            this.Type = wModel.Type;
            //WorkflowEventTaskModel.ApplyModel(this, wModel.Task);
        }
    }

    public enum WorkflowEventType
    {
        Start,
        TimerStart,
        ConditionalStart,
        Finish
    }


    public static class WorkflowEventTypeExtension
    {
        public static bool IsStart(this WorkflowEventType type) => 
            type == WorkflowEventType.Start || 
            type == WorkflowEventType.TimerStart || 
            type == WorkflowEventType.ConditionalStart;

        public static bool IsTimerOrConditionalStart(this WorkflowEventType type) =>
            type == WorkflowEventType.TimerStart ||
            type == WorkflowEventType.ConditionalStart;

        public static bool IsFinish(this WorkflowEventType type) =>
            type == WorkflowEventType.Finish;
    }

    [AutoInit]
    public static class WorkflowEventOperation
    {
        public static readonly ExecuteSymbol<WorkflowEventEntity> Save;
        public static readonly DeleteSymbol<WorkflowEventEntity> Delete;
    }

    [Serializable]
    public class WorkflowEventModel : ModelEntity
    {
        [NotNullable]
        [NotNullValidator, InTypeScript(Undefined = false, Null = false)]
        public TypeEntity MainEntityType { get; set; }

        [NotNullable, SqlDbType(Size = 100)]
        [StringLengthValidator(AllowNulls = false, Min = 3, Max = 100)]
        public string Name { get; set; }

        public WorkflowEventType Type { get; set; }
        
        public WorkflowEventTaskModel Task { get; set; }
    }
}
