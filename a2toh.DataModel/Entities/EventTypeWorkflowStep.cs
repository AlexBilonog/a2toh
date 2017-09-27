using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class EventTypeWorkflowStep : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public int EventTypeID { get; set; }
        public bool? IsActualPhaseThreshold { get; set; }
        public bool? IsBookingSuggestionThreshold { get; set; }
        public string Name { get; set; }
        public int OrderNumber { get; set; }
        public int WorkflowStepID { get; set; }

        public EventType EventType { get; set; }
        public WorkflowStep WorkflowStep { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventTypeWorkflowStep>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.EventTypeWorkflowSteps)
                    .HasForeignKey(d => d.EventTypeID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.WorkflowStep)
                    .WithMany(p => p.EventTypeWorkflowSteps)
                    .HasForeignKey(d => d.WorkflowStepID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
