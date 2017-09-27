using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class Role : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public ICollection<PermissionRole> PermissionRoles { get; set; } = new HashSet<PermissionRole>();
        public ICollection<User> Users { get; set; } = new HashSet<User>();
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
