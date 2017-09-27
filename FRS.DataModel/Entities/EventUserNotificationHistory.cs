using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class EventUserNotificationHistory : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int EventId { get; set; }
        public bool IsRequest { get; set; }
        public int? RepliedHistoryId { get; set; }
        public int? RepresenterUserId { get; set; }
        public int SendingUserId { get; set; }
        public DateTime SendTime { get; set; }

        public ICollection<EventUserNotificationHistory> EventUserNotificationHistory1 { get; set; } = new HashSet<EventUserNotificationHistory>();
        public Event Event { get; set; }
        public EventUserNotificationHistory EventUserNotificationHistory2 { get; set; }
        public User User { get; set; }
        public User User1 { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventUserNotificationHistory>(entity =>
            {
                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventUserNotificationHistories)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventUserNotificationHistory2)
                    .WithMany(p => p.EventUserNotificationHistory1)
                    .HasForeignKey(d => d.RepliedHistoryId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventUserNotificationHistories)
                    .HasForeignKey(d => d.RepresenterUserId);

                entity.HasOne(d => d.User1)
                    .WithMany(p => p.EventUserNotificationHistories1)
                    .HasForeignKey(d => d.SendingUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
