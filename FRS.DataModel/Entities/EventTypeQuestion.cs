using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class EventTypeQuestion : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public int CostQuestionVersionId { get; set; }
        public int EventId { get; set; }
        public bool IsYes { get; set; }
        public int OrderNumber { get; set; }

        public CostQuestionVersion CostQuestionVersion { get; set; }
        public Event Event { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventTypeQuestion>(entity =>
            {
                entity.HasOne(d => d.CostQuestionVersion)
                    .WithMany(p => p.EventTypeQuestions)
                    .HasForeignKey(d => d.CostQuestionVersionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventTypeQuestions)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
