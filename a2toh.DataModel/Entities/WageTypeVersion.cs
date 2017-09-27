using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManager.DataModel.Entities
{
    public partial class WageTypeVersion : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int EventTypeVersionID { get; set; }
        public int? SystemWageTypeID { get; set; }
        public int WageTypeID { get; set; }

        public EventTypeVersion EventTypeVersion { get; set; }
        public SystemWageType SystemWageType { get; set; }
        public WageType WageType { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WageTypeVersion>(entity =>
            {
                entity.HasOne(d => d.EventTypeVersion)
                    .WithMany(p => p.WageTypeVersions)
                    .HasForeignKey(d => d.EventTypeVersionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SystemWageType)
                    .WithMany(p => p.WageTypeVersions)
                    .HasForeignKey(d => d.SystemWageTypeID);

                entity.HasOne(d => d.WageType)
                    .WithMany(p => p.WageTypeVersions)
                    .HasForeignKey(d => d.WageTypeID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
