using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class StepSkipConditionCriteria : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public int? ConditionCriteriaOperatorID { get; set; }
        public int ConditionOperatorID { get; set; }
        public int OrderNumber { get; set; }
        public int StepSkipConditionID { get; set; }
        public string Value { get; set; }
        public int WorkflowStepID { get; set; }
        public string BasicFieldCode { get; set; }
        public int? BasicFieldEventTypeID { get; set; }

        public ConditionCriteriaOperator ConditionCriteriaOperator { get; set; }
        public ConditionOperator ConditionOperator { get; set; }
        public StepSkipCondition StepSkipCondition { get; set; }
        public WorkflowStep WorkflowStep { get; set; }
        public EventType BasicFieldEventType { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StepSkipConditionCriteria>(entity =>
            {
                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ConditionCriteriaOperator)
                    .WithMany(p => p.StepSkipConditionCriterias)
                    .HasForeignKey(d => d.ConditionCriteriaOperatorID);

                entity.HasOne(d => d.ConditionOperator)
                    .WithMany(p => p.StepSkipConditionCriterias)
                    .HasForeignKey(d => d.ConditionOperatorID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.StepSkipCondition)
                    .WithMany(p => p.StepSkipConditionCriterias)
                    .HasForeignKey(d => d.StepSkipConditionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.WorkflowStep)
                    .WithMany(p => p.StepSkipConditionCriterias)
                    .HasForeignKey(d => d.WorkflowStepID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.BasicFieldEventType)
                    .WithMany()
                    .HasForeignKey(d => d.BasicFieldEventTypeID);
            });
        }
    }
}
