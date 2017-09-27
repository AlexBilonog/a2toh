using EventManager.Common.Contracts;
using EventManager.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManager.DataModel.Entities
{
    public partial class CostAllocationUserNotificationRecipient : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        public User User { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostAllocationUserNotificationRecipient>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.CostAllocationUserNotificationRecipients)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
