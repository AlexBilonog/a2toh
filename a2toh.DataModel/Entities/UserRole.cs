using EventManager.Common.Contracts;
using EventManager.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManager.DataModel.Entities
{
    public partial class UserRole : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int ID { get; set; }
        public string DataRoleIDs { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.DataRoleIDs).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
