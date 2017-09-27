using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public class AttendeePlaceReservation : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public int VipLoungePlaceId { get; set; }
        public int EventId { get; set; }
        public int? ReservedAttendeeId { get; set; }
        public int? AssignedAttendeeId { get; set; }
        public int? AssignedAttendeeEventId { get; set; }
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
                    .HasForeignKey(d => d.VipLoungePlaceId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ReservedAttendee)
                    .WithMany()
                    .HasForeignKey(d => d.ReservedAttendeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.AssignedAttendee)
                    .WithMany()
                    .HasForeignKey(d => d.AssignedAttendeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.AssignedAttendeeEvent)
                    .WithOne(p => p.AttendeePlaceReservation)
                    .HasForeignKey<AttendeePlaceReservation>(d => d.AssignedAttendeeEventId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.AttendeePlaceReservations)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
