using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public class AttendeePlaceReservation : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public int VipLoungePlaceID { get; set; }
        public int EventID { get; set; }
        public int? ReservedAttendeeID { get; set; }
        public int? AssignedAttendeeID { get; set; }
        public int? AssignedAttendeeEventID { get; set; }
        public bool IsPlanned { get; set; }

        public VipLoungePlace VipLoungePlace { get; set; }
        public Attendee ReservedAttendee { get; set; }
        public Attendee AssignedAttendee { get; set; }
        public AttendeeEvent AssignedAttendeeEvent { get; set; }
        public Event Event { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendeePlaceReservation>(entity =>
            {
                entity.HasOne(d => d.VipLoungePlace)
                    .WithMany(p => p.AttendeePlaceReservations)
                    .HasForeignKey(d => d.VipLoungePlaceID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ReservedAttendee)
                    .WithMany()
                    .HasForeignKey(d => d.ReservedAttendeeID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.AssignedAttendee)
                    .WithMany()
                    .HasForeignKey(d => d.AssignedAttendeeID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.AssignedAttendeeEvent)
                    .WithOne(p => p.AttendeePlaceReservation)
                    .HasForeignKey<AttendeePlaceReservation>(d => d.AssignedAttendeeEventID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.AttendeePlaceReservations)
                    .HasForeignKey(d => d.EventID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
