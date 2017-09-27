using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class VipLoungeUserNotification : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int Id { get; set; }
        public int NotificationUserId { get; set; }
        public int VipLoungeId { get; set; }

        public User User { get; set; }
        public VipLounge VipLounge { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungeUserNotification>(entity =>
            {
                entity.HasIndex(e => new { e.VipLoungeId, e.NotificationUserId })
                    .IsUnique();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VipLoungeUserNotifications)
                    .HasForeignKey(d => d.NotificationUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.VipLounge)
                    .WithMany(p => p.VipLoungeUserNotifications)
                    .HasForeignKey(d => d.VipLoungeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
