using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class Cost : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public decimal Brutto { get; set; }
        public string Comment { get; set; }
        public int? CostAllocationStatusID { get; set; }
        public int TaxCodeID { get; set; }
        public int? CostCategoryVersionID { get; set; }
        public string DocumentID { get; set; }
        public int? EventID { get; set; }
        public int? GiftID { get; set; }
        public bool IsAllocated { get; set; }
        public bool IsCommited { get; set; }
        public bool IsForAllocation { get; set; }
        public bool IsLastLevelCost { get; set; }
        public bool IsPlanned { get; set; }
        public decimal Netto { get; set; }
        public int? ParentCostID { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string RegisterNumber { get; set; }
        public int? SourceTypeID { get; set; }
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
                    .HasForeignKey(d => d.CostAllocationStatusID);

                entity.HasOne(d => d.CostCategoryVersion)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.CostCategoryVersionID);

                entity.HasOne(d => d.TaxCode)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.TaxCodeID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.EventID);

                entity.HasOne(d => d.Gift)
                   .WithMany(p => p.Costs)
                   .HasForeignKey(d => d.GiftID);

                entity.HasOne(d => d.ParentCost)
                    .WithMany(p => p.ChildCosts)
                    .HasForeignKey(d => d.ParentCostID);

                entity.HasOne(d => d.SourceType)
                    .WithMany(p => p.Costs)
                    .HasForeignKey(d => d.SourceTypeID);
            });
        }
    }
}
