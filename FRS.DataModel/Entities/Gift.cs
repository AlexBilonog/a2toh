using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class Gift : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public int? ResponsibleUserId { get; set; }
        public int? CostCenterId { get; set; }
        public string PurposeOfUse { get; set; }
        public DateTime? Date { get; set; }
        public string ProductNo { get; set; }
        public string ProductDescription { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? GrantedHeroes { get; set; }
        public int? Available { get; set; }
        public decimal? TotalCost { get; set; }
        public bool IsActive { get; set; }
        public bool IsReleased { get; set; }
        public int Difference { get; set; }
        public bool IsDifferenceExplained { get; set; }
        public string Comment { get; set; }

        public ICollection<AttendeeAllocatedCostValue> AttendeeAllocatedGiftValues { get; set; } = new HashSet<AttendeeAllocatedCostValue>();
        public ICollection<Cost> Costs { get; set; } = new HashSet<Cost>();
        public User User { get; set; }
        public CostCenter CostCenter { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gift>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Gifts)
                    .HasForeignKey(d => d.ResponsibleUserId);

                entity.HasOne(d => d.CostCenter)
                    .WithMany(p => p.Gifts)
                    .HasForeignKey(d => d.CostCenterId);
            });
        }
    }
}
