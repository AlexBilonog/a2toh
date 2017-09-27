using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class VipLoungeCostFlexibleField : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public int CostFlexibleFieldVersionId { get; set; }
        public bool? Value { get; set; }
        public int VipLoungeId { get; set; }

        public CostFlexibleFieldVersion CostFlexibleFieldVersion { get; set; }
        public VipLounge VipLounge { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungeCostFlexibleField>(entity =>
            {
                entity.HasOne(d => d.CostFlexibleFieldVersion)
                    .WithMany(p => p.VipLoungeCostFlexibleFields)
                    .HasForeignKey(d => d.CostFlexibleFieldVersionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.VipLounge)
                    .WithMany(p => p.VipLoungeCostFlexibleFields)
                    .HasForeignKey(d => d.VipLoungeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
