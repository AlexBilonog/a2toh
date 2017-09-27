using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class Cost : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public decimal Brutto { get; set; }
        public string Comment { get; set; }
        public int? CostAllocationStatusId { get; set; }
        public int TaxCodeId { get; set; }
        public int? CostCategoryVersionId { get; set; }
        public string DocumentId { get; set; }
        public int? EventId { get; set; }
        public int? GiftId { get; set; }
        public bool IsAllocated { get; set; }
        public bool IsCommited { get; set; }
        public bool IsForAllocation { get; set; }
        public bool IsLastLevelCost { get; set; }
        public bool IsPlanned { get; set; }
        public decimal Netto { get; set; }
        public int? ParentCostId { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string RegisterNumber { get; set; }
        public int? SourceTypeId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierNumber { get; set; }
        public bool? IsCreatedForGift { get; set; }
        public int? SelectedGifts { get; set; }
        public int? AllocatedGift { get; set; }

        public ICollection<AttendeeAllocatedCostValue> AttendeeAllocatedCostValues { get; set; } = new HashSet<AttendeeAllocatedCostValue>();
        public CostAllocationStatuss CostAllocationStatuss { get; set; }
        public CostCategoryVersion CostCategoryVersion { get; set; }
        public TaxCode TaxCode { get; set; }
        public Event Event { get; set; }
        public Gift Gift { get; set; }
        public Cost ParentCost { get; set; }
        public ICollection<Cost> ChildCosts { get; set; } = new HashSet<Cost>();
        public SourceType SourceType { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cost>(entity =>
            {
                entity.Property(e => e.Comment).HasMaxLength(500);

                entity.Property(e => e.RegisterNumber).HasMaxLength(100);

                entity.Property(e => e.SupplierName).HasMaxLength(100);

                entity.Property(e => e.SupplierNumber).HasMaxLength(100);

                entity.HasOne(d => d.CostAllocationStatuss)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.CostAllocationStatusId);

                entity.HasOne(d => d.CostCategoryVersion)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.CostCategoryVersionId);

                entity.HasOne(d => d.TaxCode)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.TaxCodeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.EventId);

                entity.HasOne(d => d.Gift)
                   .WithMany(p => p.Costs)
                   .HasForeignKey(d => d.GiftId);

                entity.HasOne(d => d.ParentCost)
                    .WithMany(p => p.ChildCosts)
                    .HasForeignKey(d => d.ParentCostId);

                entity.HasOne(d => d.SourceType)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.SourceTypeId);
            });
        }
    }
}
