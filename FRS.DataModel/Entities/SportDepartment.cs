using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public class SportDepartment : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public int SportId { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }

        public Sport Sport { get; set; }
        public Department Department { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SportDepartment>(entity =>
            {
                entity.HasOne(d => d.Sport)
                    .WithMany()
                    .HasForeignKey(d => d.SportId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.SportDepartments)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(d => new { d.DepartmentId, d.SportId })
                    .IsUnique();
            });
        }
    }
}