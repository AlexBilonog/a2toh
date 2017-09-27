using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class UserSetting : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public User User { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSetting>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
