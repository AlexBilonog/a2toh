using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class EventUserNotificationRecipientType : IEntity, IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EventUserNotificationRecipient> EventUserNotificationRecipients { get; set; } = new HashSet<EventUserNotificationRecipient>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventUserNotificationRecipientType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
