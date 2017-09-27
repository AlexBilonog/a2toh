using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class CostAllocationUserNotificationRecipient : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostAllocationUserNotificationRecipient>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.CostAllocationUserNotificationRecipients)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
