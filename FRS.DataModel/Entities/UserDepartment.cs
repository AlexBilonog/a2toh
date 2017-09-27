using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace FRS.DataModel.Entities
{
    public partial class UserDepartment : AuditInfo, IEntity, IHasValidityPeriod, IHasUser, IHasId
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public DateTime SetDateTime { get; set; }
        public int UserId { get; set; }
        public DateTime ValidFromDate { get; set; }
        public DateTime ValidToDate { get; set; }

        public Department Department { get; set; }
        public User User { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDepartment>(entity =>
            {
                entity.HasOne(d => d.Department)
                    .WithMany(p => p.UserDepartments)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDepartments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
