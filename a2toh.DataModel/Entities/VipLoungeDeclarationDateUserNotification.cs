using EventManager.Common.Contracts;
using EventManager.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManager.DataModel.Entities
{
    public partial class VipLoungeDeclarationDateUserNotification : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int ID { get; set; }
        public bool? IsEmailSent { get; set; }
        public int NotificationUserID { get; set; }
        public int VipLoungeDeclarationDateID { get; set; }

        public User User { get; set; }
        public VipLoungeDeclarationDate VipLoungeDeclarationDate { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungeDeclarationDateUserNotification>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.VipLoungeDeclarationDateUserNotifications)
                    .HasForeignKey(d => d.NotificationUserID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.VipLoungeDeclarationDate)
                    .WithMany(p => p.VipLoungeDeclarationDateUserNotifications)
                    .HasForeignKey(d => d.VipLoungeDeclarationDateID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
