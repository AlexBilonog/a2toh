using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class EventUserNotificationRecipient : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int EventUserNotificationRecipientTypeID { get; set; }
        public int UserID { get; set; }

        public Event Event { get; set; }
        public EventUserNotificationRecipientType EventUserNotificationRecipientType { get; set; }
        public User User { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventUserNotificationRecipient>(entity =>
            {
                entity.HasIndex(e => new { e.EventID, e.UserID, e.EventUserNotificationRecipientTypeID })
                    .IsUnique();

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventUserNotificationRecipients)
                    .HasForeignKey(d => d.EventID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventUserNotificationRecipientType)
                    .WithMany(p => p.EventUserNotificationRecipients)
                    .HasForeignKey(d => d.EventUserNotificationRecipientTypeID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventUserNotificationRecipients)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
