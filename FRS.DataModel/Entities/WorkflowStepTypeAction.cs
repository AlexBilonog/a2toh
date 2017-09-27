using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class WorkflowStepTypeAction : IEntity, IHasId, IHasDescription
    {
        public WorkflowStepTypeAction()
        {
            EmailTemplates = new HashSet<EmailTemplate>();
            EventWorkflowStepHistories = new HashSet<EventWorkflowStepHistory>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int WorkflowStepTypeId { get; set; }

        public ICollection<EmailTemplate> EmailTemplates { get; set; }
        public ICollection<EventWorkflowStepHistory> EventWorkflowStepHistories { get; set; }
        public WorkflowStepType WorkflowStepType { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkflowStepTypeAction>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.WorkflowStepType)
                    .WithMany(p => p.WorkflowStepTypeActions)
                    .HasForeignKey(d => d.WorkflowStepTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
