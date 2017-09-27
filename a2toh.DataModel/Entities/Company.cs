using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EventManager.DataModel.Entities
{
    public partial class Company : AuditInfo, IEntity, IHasActiveState, IHasId, IHasDescription
    {
        public Company()
        {
            IsActive = true;
        }

        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }

        public ICollection<AttendeeEvent> AttendeeEvents { get; set; } = new HashSet<AttendeeEvent>();
        public ICollection<AttendeeHistory> AttendeeHistories { get; set; } = new HashSet<AttendeeHistory>();
        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();
        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
        public ICollection<ReportDocument> ReportDocuments { get; set; } = new HashSet<ReportDocument>();
        public ICollection<SocialSecurityReport> SocialSecurityReports { get; set; } = new HashSet<SocialSecurityReport>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasIndex(e => e.Code).IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
