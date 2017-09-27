using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class UserRole : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int Id { get; set; }
        public string DataRoleIds { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.DataRoleIds).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
