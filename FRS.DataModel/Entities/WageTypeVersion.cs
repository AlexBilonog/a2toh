using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class WageTypeVersion : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int EventTypeVersionId { get; set; }
        public int? SystemWageTypeId { get; set; }
        public int WageTypeId { get; set; }

        public EventTypeVersion EventTypeVersion { get; set; }
        public SystemWageType SystemWageType { get; set; }
        public WageType WageType { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WageTypeVersion>(entity =>
            {
                entity.HasOne(d => d.EventTypeVersion)
                    .WithMany(p => p.WageTypeVersions)
                    .HasForeignKey(d => d.EventTypeVersionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SystemWageType)
                    .WithMany(p => p.WageTypeVersions)
                    .HasForeignKey(d => d.SystemWageTypeId);

                entity.HasOne(d => d.WageType)
                    .WithMany(p => p.WageTypeVersions)
                    .HasForeignKey(d => d.WageTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
