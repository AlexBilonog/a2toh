using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class PermissionRole : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public int PermissionID { get; set; }
        public int RoleID { get; set; }

        public Permission Permission { get; set; }
        public Role Role { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionRole>(entity =>
            {
                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionRoles)
                    .HasForeignKey(d => d.PermissionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PermissionRoles)
                    .HasForeignKey(d => d.RoleID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
