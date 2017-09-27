using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class EventBasicField : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public int BasicFieldVersionID { get; set; }
        public int EventID { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }

        public BasicFieldVersion BasicFieldVersion { get; set; }
        public Event Event { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventBasicField>(entity =>
            {
                entity.Property(e => e.Value1).HasMaxLength(500);

                entity.Property(e => e.Value2).HasMaxLength(500);

                entity.HasOne(d => d.BasicFieldVersion)
                    .WithMany(p => p.EventBasicFields)
                    .HasForeignKey(d => d.BasicFieldVersionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventBasicFields)
                    .HasForeignKey(d => d.EventID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
