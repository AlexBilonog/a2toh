using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class Department : AuditInfo, IEntity, IHasActiveState, IHasId, IHasDescription
    {
        public Department()
        {
            IsActive = true;
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }

        public ICollection<AttendeeHistory> AttendeeHistories { get; set; } = new HashSet<AttendeeHistory>();
        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
        public ICollection<UserDepartment> UserDepartments { get; set; } = new HashSet<UserDepartment>();
        public ICollection<VipLounge> VipLounges { get; set; } = new HashSet<VipLounge>();
        public ICollection<VipLoungePlace> VipLoungePlaces { get; set; } = new HashSet<VipLoungePlace>();
        public ICollection<SportDepartment> SportDepartments { get; set; } = new HashSet<SportDepartment>();
        public Company Company { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(440);

                entity.HasIndex(e => new { e.CompanyId, e.Name }).IsUnique();

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
