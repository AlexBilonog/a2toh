using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class CostCategoryVersion : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int ID { get; set; }
        public bool Allocatable { get; set; }
        public int CostCategoryID { get; set; }
        public string Description { get; set; }
        public int EventTypeVersionID { get; set; }
        public bool IsDecimalType { get; set; }
        public bool? IsForVipLounge { get; set; }
        public bool IsMandatory { get; set; }
        public bool? IsVipLoungeExtraCategory { get; set; }
        public string Tooltip { get; set; }
        public int? SystemCostCategoryID { get; set; }

        public ICollection<Cost> Costs { get; set; } = new HashSet<Cost>();
        public ICollection<CostAllocationReason> CostAllocationReasons { get; set; } = new HashSet<CostAllocationReason>();
        public ICollection<VipLoungeCostCategory> VipLoungeCostCategories { get; set; } = new HashSet<VipLoungeCostCategory>();
        public CostCategory CostCategory { get; set; }
        public EventTypeVersion EventTypeVersion { get; set; }
        public SystemCostCategory SystemCostCategory { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostCategoryVersion>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.CostCategory)
                    .WithMany(p => p.CostCategoryVersions)
                    .HasForeignKey(d => d.CostCategoryID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventTypeVersion)
                    .WithMany(p => p.CostCategoryVersions)
                    .HasForeignKey(d => d.EventTypeVersionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SystemCostCategory)
                    .WithMany(p => p.CostCategoryVersions)
                    .HasForeignKey(d => d.SystemCostCategoryID);
            });
        }
    }
}