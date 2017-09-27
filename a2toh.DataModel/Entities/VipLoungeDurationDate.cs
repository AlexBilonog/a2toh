using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace EventManager.DataModel.Entities
{
    public partial class VipLoungeDurationDate : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int ID { get; set; }
        public decimal CostCategory1Actual { get; set; }
        public decimal CostCategory1Plan { get; set; }
        public decimal CostCategory2Actual { get; set; }
        public decimal CostCategory2Plan { get; set; }
        public decimal CostCategory3Actual { get; set; }
        public decimal CostCategory3Plan { get; set; }
        public decimal? CostCategory4Actual { get; set; }
        public decimal? CostCategory4Plan { get; set; }
        public DateTime? DeclarationDate { get; set; }
        public int? DeclarationDateID { get; set; }
        public string Description { get; set; }
        public bool IsOnhold { get; set; }
        public bool? IsUnavailable { get; set; }
        public int? UsedInEventID { get; set; }
        public int VipLoungeID { get; set; }
        public int? CompetitorId { get; set; }

        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
        public VipLoungeDeclarationDate VipLoungeDeclarationDate { get; set; }
        public Event Event { get; set; }
        public VipLounge VipLounge { get; set; }
        public Competitor Competitor { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungeDurationDate>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.HasOne(d => d.VipLoungeDeclarationDate)
                    .WithMany(p => p.VipLoungeDurationDates)
                    .HasForeignKey(d => d.DeclarationDateID);

                entity.HasOne(d => d.Competitor)
                    .WithMany(p=>p.VipLoungeDurationDates)
                    .HasForeignKey(d => d.CompetitorId);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.VipLoungeDurationDates)
                    .HasForeignKey(d => d.UsedInEventID);

                entity.HasOne(d => d.VipLounge)
                    .WithMany(p => p.VipLoungeDurationDates)
                    .HasForeignKey(d => d.VipLoungeID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
