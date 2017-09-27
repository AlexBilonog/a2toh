using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class VipLoungeDeclarationDateUserNotification : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int Id { get; set; }
        public bool? IsEmailSent { get; set; }
        public int NotificationUserId { get; set; }
        public int VipLoungeDeclarationDateId { get; set; }

        public User User { get; set; }
        public VipLoungeDeclarationDate VipLoungeDeclarationDate { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungeDeclarationDateUserNotification>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.VipLoungeDeclarationDateUserNotifications)
                    .HasForeignKey(d => d.NotificationUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.VipLoungeDeclarationDate)
                    .WithMany(p => p.VipLoungeDeclarationDateUserNotifications)
                    .HasForeignKey(d => d.VipLoungeDeclarationDateId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
