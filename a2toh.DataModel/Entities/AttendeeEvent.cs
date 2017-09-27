using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class AttendeeEvent : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public int? AlternativeCompanyID { get; set; }
        public int? AlternativeCostCenterID { get; set; }
        public int AttendeeHistoryID { get; set; }
        public int AttendeeTypeVersionID { get; set; }
        public int EventID { get; set; }
        public bool IsCostTranfer { get; set; }
        public bool IsNotParticipated { get; set; }
        public bool IsPlanned { get; set; }
        public bool IsSupervisor { get; set; }
        public bool IsHonored { get; set; }
        public bool IsProducer { get; set; }
        public string Comment { get; set; }
        public bool IsChargingOn { get; set; }

        public ICollection<AttendeeAllocatedCostValue> AttendeeAllocatedCostValues { get; set; } = new HashSet<AttendeeAllocatedCostValue>();
        public ICollection<AttendeeEventBasicField> AttendeeEventBasicFields { get; set; } = new HashSet<AttendeeEventBasicField>();
        public Company Company { get; set; }
        public CostCenter AlternativeCostCenter { get; set; }
        public AttendeeHistory AttendeeHistory { get; set; }
        public AttendeePlaceReservation AttendeePlaceReservation { get; set; }
        public AttendeeTypeVersion AttendeeTypeVersion { get; set; }
        public Event Event { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendeeEvent>(entity =>
            {
                entity.HasOne(d => d.Company)
                    .WithMany(p => p.AttendeeEvents)
                    .HasForeignKey(d => d.AlternativeCompanyID);

                entity.HasOne(d => d.AlternativeCostCenter)
                    .WithMany(p => p.AttendeeEvents)
                    .HasForeignKey(d => d.AlternativeCostCenterID);

                entity.HasOne(d => d.AttendeeHistory)
                    .WithMany(p => p.AttendeeEvents)
                    .HasForeignKey(d => d.AttendeeHistoryID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.AttendeeTypeVersion)
                    .WithMany(p => p.AttendeeEvents)
                    .HasForeignKey(d => d.AttendeeTypeVersionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.AttendeeEvents)
                    .HasForeignKey(d => d.EventID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
