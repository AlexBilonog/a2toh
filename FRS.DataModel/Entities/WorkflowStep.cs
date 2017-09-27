using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class WorkflowStep : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PermissionId { get; set; }
        public int WorkflowStepTypeId { get; set; }

        public ICollection<EmailTemplate> EmailTemplates { get; set; } = new HashSet<EmailTemplate>();
        public ICollection<EventTypeWorkflowStep> EventTypeWorkflowSteps { get; set; } = new HashSet<EventTypeWorkflowStep>();
        public ICollection<EventWorkflowStep> EventWorkflowSteps { get; set; } = new HashSet<EventWorkflowStep>();
        public ICollection<StepSkipConditionCriteria> StepSkipConditionCriterias { get; set; } = new HashSet<StepSkipConditionCriteria>();
        public Permission Permission { get; set; }
        public WorkflowStepType WorkflowStepType { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkflowStep>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.WorkflowSteps)
                    .HasForeignKey(d => d.PermissionId);

                entity.HasOne(d => d.WorkflowStepType)
                    .WithMany(p => p.WorkflowSteps)
                    .HasForeignKey(d => d.WorkflowStepTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
