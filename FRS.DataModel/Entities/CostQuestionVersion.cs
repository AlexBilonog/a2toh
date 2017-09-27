using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class CostQuestionVersion : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public int EventTypeVersionID { get; set; }
        public bool? IsForEventType { get; set; }
        public bool? IsForVipLounge { get; set; }
        public string Text { get; set; }

        public ICollection<EventCostQuestion> EventCostQuestions { get; set; } = new HashSet<EventCostQuestion>();
        public ICollection<EventTypeQuestion> EventTypeQuestions { get; set; } = new HashSet<EventTypeQuestion>();
        public ICollection<VipLoungeCostQuestion> VipLoungeCostQuestions { get; set; } = new HashSet<VipLoungeCostQuestion>();
        public EventTypeVersion EventTypeVersion { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostQuestionVersion>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Text).HasMaxLength(500);

                entity.HasOne(d => d.EventTypeVersion)
                    .WithMany(p => p.CostQuestionVersions)
                    .HasForeignKey(d => d.EventTypeVersionID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
