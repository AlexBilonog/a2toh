using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace EventManager.DataModel.Entities
{
    public partial class CostFlexibleFieldVersion : IEntity, IHasId
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public int CostFlexibleFieldID { get; set; }
        public int CostFlexibleFieldTypeID { get; set; }
        public int EventTypeVersionID { get; set; }
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
                    .HasForeignKey(d => d.CostFlexibleFieldID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.CostFlexibleFieldType)
                    .WithMany(p => p.CostFlexibleFieldVersions)
                    .HasForeignKey(d => d.CostFlexibleFieldTypeID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventTypeVersion)
                    .WithMany(p => p.CostFlexibleFieldVersions)
                    .HasForeignKey(d => d.EventTypeVersionID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
