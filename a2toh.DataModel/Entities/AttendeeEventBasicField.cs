using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class AttendeeEventBasicField : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public int AttendeeBasicFieldVersionID { get; set; }
        public int AttendeeEventID { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }

        public AttendeeBasicFieldVersion AttendeeBasicFieldVersion { get; set; }
        public AttendeeEvent AttendeeEvent { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendeeEventBasicField>(entity =>
            {
                entity.Property(e => e.Value1).HasMaxLength(500);

                entity.Property(e => e.Value2).HasMaxLength(500);

                entity.HasOne(d => d.AttendeeBasicFieldVersion)
                    .WithMany(p => p.AttendeeEventBasicFields)
                    .HasForeignKey(d => d.AttendeeBasicFieldVersionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.AttendeeEvent)
                    .WithMany(p => p.AttendeeEventBasicFields)
                    .HasForeignKey(d => d.AttendeeEventID);
            });
        }
    }
}
