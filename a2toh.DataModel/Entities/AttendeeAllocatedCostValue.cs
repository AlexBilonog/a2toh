using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class AttendeeAllocatedCostValue : IEntity, IHasId
    {
        public int ID { get; set; }
        public decimal? AllocatedValue { get; set; }
        public int AttendeeEventID { get; set; }
        public int? CostAllocationReasonID { get; set; }
        public int CostID { get; set; }
        public int? GiftID { get; set; }
        public int? AllocatedGiftValue { get; set; }

        public AttendeeEvent AttendeeEvent { get; set; }
        public CostAllocationReason CostAllocationReason { get; set; }
        public Cost Cost { get; set; }
        public Gift Gift { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendeeAllocatedCostValue>(entity =>
            {
                entity.HasOne(d => d.AttendeeEvent)
                    .WithMany(p => p.AttendeeAllocatedCostValues)
                    .HasForeignKey(d => d.AttendeeEventID);

                entity.HasOne(d => d.CostAllocationReason)
                    .WithMany(p => p.AttendeeAllocatedCostValues)
                    .HasForeignKey(d => d.CostAllocationReasonID);

                entity.HasOne(d => d.Cost)
                    .WithMany(p => p.AttendeeAllocatedCostValues)
                    .HasForeignKey(d => d.CostID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Gift)
                    .WithMany(p => p.AttendeeAllocatedGiftValues)
                    .HasForeignKey(d => d.GiftID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
