using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManager.DataModel.Entities
{
    public partial class UserSetting : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public User User { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSetting>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
