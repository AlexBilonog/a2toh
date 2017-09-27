using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public class SportDepartment : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public int SportID { get; set; }
        public int DepartmentID { get; set; }
        public bool IsActive { get; set; }

        public Sport Sport { get; set; }
        public Department Department { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SportDepartment>(entity =>
            {
                entity.HasOne(d => d.Sport)
                    .WithMany()
                    .HasForeignKey(d => d.SportID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.SportDepartments)
                    .HasForeignKey(d => d.DepartmentID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(d => new { d.DepartmentID, d.SportID })
                    .IsUnique();
            });
        }
    }
}