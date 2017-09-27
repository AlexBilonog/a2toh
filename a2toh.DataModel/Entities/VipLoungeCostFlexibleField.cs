using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManager.DataModel.Entities
{
    public partial class VipLoungeCostFlexibleField : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public int CostFlexibleFieldVersionID { get; set; }
        public bool? Value { get; set; }
        public int VipLoungeID { get; set; }

        public CostFlexibleFieldVersion CostFlexibleFieldVersion { get; set; }
        public VipLounge VipLounge { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungeCostFlexibleField>(entity =>
            {
                entity.HasOne(d => d.CostFlexibleFieldVersion)
                    .WithMany(p => p.VipLoungeCostFlexibleFields)
                    .HasForeignKey(d => d.CostFlexibleFieldVersionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.VipLounge)
                    .WithMany(p => p.VipLoungeCostFlexibleFields)
                    .HasForeignKey(d => d.VipLoungeID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
