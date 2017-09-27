using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class EventUserNotificationRecipient : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int EventUserNotificationRecipientTypeId { get; set; }
        public int UserId { get; set; }

        public Event Event { get; set; }
        public EventUserNotificationRecipientType EventUserNotificationRecipientType { get; set; }
        public User User { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventUserNotificationRecipient>(entity =>
            {
                entity.HasIndex(e => new { e.EventId, e.UserId, e.EventUserNotificationRecipientTypeId })
                    .IsUnique();

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventUserNotificationRecipients)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventUserNotificationRecipientType)
                    .WithMany(p => p.EventUserNotificationRecipients)
                    .HasForeignKey(d => d.EventUserNotificationRecipientTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventUserNotificationRecipients)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
