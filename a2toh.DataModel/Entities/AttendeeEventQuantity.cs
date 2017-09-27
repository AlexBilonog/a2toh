using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManager.DataModel.Entities
{
    public partial class AttendeeEventQuantity : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public int AttendeeTypeVersionID { get; set; }
        public int EventID { get; set; }
        public bool IsPlanned { get; set; }
        public int? Quantity { get; set; }
        public int? QuantityInvitedPersons { get; set; }
        public int? SupervisorQuantity { get; set; }
        public int? SupervisorInvitedQuantity { get; set; }
        public int? HonoredQuantity { get; set; }
        public int? HonoredInvitedQuantity { get; set; }
        public int? ProducerQuantity { get; set; }
        public int? ProducerInvitedQuantity { get; set; }

        public AttendeeTypeVersion AttendeeTypeVersion { get; set; }
        public Event Event { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendeeEventQuantity>(entity =>
            {
                entity.HasOne(d => d.AttendeeTypeVersion)
                    .WithMany(p => p.AttendeeEventQuantities)
                    .HasForeignKey(d => d.AttendeeTypeVersionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.AttendeeEventQuantities)
                    .HasForeignKey(d => d.EventID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}