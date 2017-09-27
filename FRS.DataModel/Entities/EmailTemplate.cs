using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class EmailTemplate : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string CultureName { get; set; }
        public int EventTypeId { get; set; }
        public int WorkflowStepId { get; set; }
        public int WorkflowStepTypeActionId { get; set; }

        public EventType EventType { get; set; }
        public WorkflowStep WorkflowStep { get; set; }
        public WorkflowStepTypeAction WorkflowStepTypeAction { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailTemplate>(entity =>
            {
                entity.Property(e => e.CultureName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.EmailTemplates)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.WorkflowStep)
                    .WithMany(p => p.EmailTemplates)
                    .HasForeignKey(d => d.WorkflowStepId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.WorkflowStepTypeAction)
                    .WithMany(p => p.EmailTemplates)
                    .HasForeignKey(d => d.WorkflowStepTypeActionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
