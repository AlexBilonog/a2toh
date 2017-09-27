using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class Permission : IEntity, IHasId, IHasDescription
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int PermissionTypeId { get; set; }

        public ICollection<PermissionRole> PermissionRoles { get; set; } = new HashSet<PermissionRole>();
        public ICollection<WorkflowStep> WorkflowSteps { get; set; } = new HashSet<WorkflowStep>();
        public PermissionType PermissionType { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.PermissionType)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.PermissionTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
