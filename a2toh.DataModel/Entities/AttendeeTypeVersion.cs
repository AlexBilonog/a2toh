using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace EventManager.DataModel.Entities
{
    public partial class AttendeeTypeVersion : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int ID { get; set; }
        public int AttendeeTypeID { get; set; }
        public string Description { get; set; }
        public int EventTypeVersionID { get; set; }
        public bool IsDepartmentMandatory { get; set; }
        public bool IsCompanyMandatory { get; set; }
        public bool? IsExternal { get; set; }
        public bool IsInvitedPerson { get; set; }
        public bool IsInvitedPersonAllowed { get; set; }
        public bool? IsTaxRelevant { get; set; }
        public string Tooltip { get; set; }
        public int? SystemAttendeeTypeID { get; set; }
        public int OrderNumber { get; set; }
        public bool IsSupervisorAllowed { get; set; }
        public bool IsHonoredAllowed { get; set; }
        public bool IsProducerAllowed { get; set; }

        public ICollection<AttendeeEvent> AttendeeEvents { get; set; } = new HashSet<AttendeeEvent>();
        public ICollection<AttendeeEventQuantity> AttendeeEventQuantities { get; set; } = new HashSet<AttendeeEventQuantity>();
        public AttendeeType AttendeeType { get; set; }
        public EventTypeVersion EventTypeVersion { get; set; }
        public SystemAttendeeType SystemAttendeeType { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendeeTypeVersion>(entity =>
            {
                entity.HasOne(d => d.AttendeeType)
                    .WithMany(p => p.AttendeeTypeVersions)
                    .HasForeignKey(d => d.AttendeeTypeID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventTypeVersion)
                    .WithMany(p => p.AttendeeTypeVersions)
                    .HasForeignKey(d => d.EventTypeVersionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SystemAttendeeType)
                    .WithMany(p => p.AttendeeTypeVersions)
                    .HasForeignKey(d => d.SystemAttendeeTypeID);
            });
        }
    }
}
