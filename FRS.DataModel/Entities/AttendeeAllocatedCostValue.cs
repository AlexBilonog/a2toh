using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class AttendeeAllocatedCostValue : IEntity, IHasId
    {
        public int Id { get; set; }
        public decimal? AllocatedValue { get; set; }
        public int AttendeeEventId { get; set; }
        public int? CostAllocationReasonId { get; set; }
        public int CostId { get; set; }
        public int? GiftId { get; set; }
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
                    .HasForeignKey(d => d.AttendeeEventId);

                entity.HasOne(d => d.CostAllocationReason)
                    .WithMany(p => p.AttendeeAllocatedCostValues)
                    .HasForeignKey(d => d.CostAllocationReasonId);

                entity.HasOne(d => d.Cost)
                    .WithMany(p => p.AttendeeAllocatedCostValues)
                    .HasForeignKey(d => d.CostId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Gift)
                    .WithMany(p => p.AttendeeAllocatedGiftValues)
                    .HasForeignKey(d => d.GiftId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
