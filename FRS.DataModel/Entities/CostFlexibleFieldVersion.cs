using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class CostFlexibleFieldVersion : IEntity, IHasId
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int CostFlexibleFieldId { get; set; }
        public int CostFlexibleFieldTypeId { get; set; }
        public int EventTypeVersionId { get; set; }
        public bool? IsForVipLounge { get; set; }
        public bool? IsVipLoungeExtraCostVisible { get; set; }
        public string Name { get; set; }
        public bool? DefaultValue { get; set; }
        public int OrderNumber { get; set; }

        public ICollection<EventCostFlexibleField> EventCostFlexibleFields { get; set; } = new HashSet<EventCostFlexibleField>();
        public ICollection<VipLoungeCostFlexibleField> VipLoungeCostFlexibleFields { get; set; } = new HashSet<VipLoungeCostFlexibleField>();
        public CostFlexibleField CostFlexibleField { get; set; }
        public CostFlexibleFieldType CostFlexibleFieldType { get; set; }
        public EventTypeVersion EventTypeVersion { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostFlexibleFieldVersion>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.CostFlexibleField)
                    .WithMany(p => p.CostFlexibleFieldVersions)
                    .HasForeignKey(d => d.CostFlexibleFieldId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.CostFlexibleFieldType)
                    .WithMany(p => p.CostFlexibleFieldVersions)
                    .HasForeignKey(d => d.CostFlexibleFieldTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventTypeVersion)
                    .WithMany(p => p.CostFlexibleFieldVersions)
                    .HasForeignKey(d => d.EventTypeVersionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
