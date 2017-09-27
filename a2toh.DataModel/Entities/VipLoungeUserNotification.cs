using EventManager.Common.Contracts;
using EventManager.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManager.DataModel.Entities
{
    public partial class VipLoungeUserNotification : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int ID { get; set; }
        public int NotificationUserID { get; set; }
        public int VipLoungeID { get; set; }

        public User User { get; set; }
        public VipLounge VipLounge { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungeUserNotification>(entity =>
            {
                entity.HasIndex(e => new { e.VipLoungeID, e.NotificationUserID })
                    .IsUnique();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VipLoungeUserNotifications)
                    .HasForeignKey(d => d.NotificationUserID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.VipLounge)
                    .WithMany(p => p.VipLoungeUserNotifications)
                    .HasForeignKey(d => d.VipLoungeID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
