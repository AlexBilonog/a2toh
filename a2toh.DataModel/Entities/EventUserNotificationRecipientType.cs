using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EventManager.DataModel.Entities
{
    public partial class EventUserNotificationRecipientType : IEntity, IHasId
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<EventUserNotificationRecipient> EventUserNotificationRecipients { get; set; } = new HashSet<EventUserNotificationRecipient>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventUserNotificationRecipientType>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
