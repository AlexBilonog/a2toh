using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class WageTypeMapping : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int EventTypeId { get; set; }
        public string MappedValue { get; set; }
        public int WageTypeId { get; set; }

        public EventType EventType { get; set; }
        public WageType WageType { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WageTypeMapping>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(440);

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.WageTypeMappings)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.WageType)
                    .WithMany(p => p.WageTypeMappings)
                    .HasForeignKey(d => d.WageTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
