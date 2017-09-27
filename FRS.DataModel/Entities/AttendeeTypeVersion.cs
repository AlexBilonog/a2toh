using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class AttendeeTypeVersion : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int Id { get; set; }
        public int AttendeeTypeId { get; set; }
        public string Description { get; set; }
        public int EventTypeVersionId { get; set; }
        public bool IsDepartmentMandatory { get; set; }
        public bool IsCompanyMandatory { get; set; }
        public bool? IsExternal { get; set; }
        public bool IsInvitedPerson { get; set; }
        public bool IsInvitedPersonAllowed { get; set; }
        public bool? IsTaxRelevant { get; set; }
        public string Tooltip { get; set; }
        public int? SystemAttendeeTypeId { get; set; }
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
                    .HasForeignKey(d => d.AttendeeTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventTypeVersion)
                    .WithMany(p => p.AttendeeTypeVersions)
                    .HasForeignKey(d => d.EventTypeVersionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SystemAttendeeType)
                    .WithMany(p => p.AttendeeTypeVersions)
                    .HasForeignKey(d => d.SystemAttendeeTypeId);
            });
        }
    }
}
