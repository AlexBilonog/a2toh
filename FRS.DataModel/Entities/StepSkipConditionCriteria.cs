using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class StepSkipConditionCriteria : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public int? ConditionCriteriaOperatorId { get; set; }
        public int ConditionOperatorId { get; set; }
        public int OrderNumber { get; set; }
        public int StepSkipConditionId { get; set; }
        public string Value { get; set; }
        public int WorkflowStepId { get; set; }
        public string BasicFieldCode { get; set; }
        public int? BasicFieldEventTypeId { get; set; }

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
                    .HasForeignKey(d => d.ConditionCriteriaOperatorId);

                entity.HasOne(d => d.ConditionOperator)
                    .WithMany(p => p.StepSkipConditionCriterias)
                    .HasForeignKey(d => d.ConditionOperatorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.StepSkipCondition)
                    .WithMany(p => p.StepSkipConditionCriterias)
                    .HasForeignKey(d => d.StepSkipConditionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.WorkflowStep)
                    .WithMany(p => p.StepSkipConditionCriterias)
                    .HasForeignKey(d => d.WorkflowStepId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.BasicFieldEventType)
                    .WithMany()
                    .HasForeignKey(d => d.BasicFieldEventTypeId);
            });
        }
    }
}
