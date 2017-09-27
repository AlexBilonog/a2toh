using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace EventManager.DataModel.Entities
{
    public partial class CostAllocationReason : IEntity, IHasId, IHasDescription
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public int CostCategoryVersionID { get; set; }
        public string Description { get; set; }

        public ICollection<AttendeeAllocatedCostValue> AttendeeAllocatedCostValues { get; set; } = new HashSet<AttendeeAllocatedCostValue>();
        public CostCategoryVersion CostCategoryVersion { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostAllocationReason>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.CostCategoryVersion)
                    .WithMany(p => p.CostAllocationReasons)
                    .HasForeignKey(d => d.CostCategoryVersionID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
