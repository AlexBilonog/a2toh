using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class EmailTemplate : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public string CultureName { get; set; }
        public int EventTypeID { get; set; }
        public int WorkflowStepID { get; set; }
        public int WorkflowStepTypeActionID { get; set; }

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
                    .HasForeignKey(d => d.EventTypeID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.WorkflowStep)
                    .WithMany(p => p.EmailTemplates)
                    .HasForeignKey(d => d.WorkflowStepID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.WorkflowStepTypeAction)
                    .WithMany(p => p.EmailTemplates)
                    .HasForeignKey(d => d.WorkflowStepTypeActionID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
