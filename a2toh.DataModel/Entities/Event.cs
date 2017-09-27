using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class Event : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int ID { get; set; }
        public decimal? ActualCosts { get; set; }
        public string Comments { get; set; }
        public int CompanyID { get; set; }
        public int? CostCenterID { get; set; }
        public int? OrderNumberID { get; set; }
        public string CostCenterText { get; set; }
        public string OrderNumberText { get; set; }
        public int CreationUserID { get; set; }
        public int DepartmentID { get; set; }
        public string EventNo { get; set; }
        public int EventTypeVersionID { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsAssignAttendeesIndividuallyActual { get; set; }
        public bool IsAssignAttendeesIndividuallyPlanned { get; set; }
        public bool? IsBookingSuggestionActualPhase { get; set; }
        public bool? IsCancelled { get; set; }
        public bool? IsClosed { get; set; }
        public bool IsClosing { get; set; }
        public bool IsCopyAndCancelChildEvent { get; set; }
        public bool IsDeprecated { get; set; }
        public bool IsInActualPhase { get; set; }
        public DateTime? LastChangeDateTime { get; set; }
        public int? LastChangeUserID { get; set; }
        public string Name { get; set; }
        public decimal? PlannedCosts { get; set; }
        public string ProjectNumber { get; set; }
        public string Reason { get; set; }
        public int? RepresenterUserID { get; set; }
        public int? SourceID { get; set; }
        public DateTime StartDate { get; set; }
        public int StatusID { get; set; }
        public DateTime? TaxationDate { get; set; }
        public int? VipLoungeDurationDateID { get; set; }

        public ICollection<Agenda> Agenda { get; set; } = new HashSet<Agenda>();
        public ICollection<AttendeeEvent> AttendeeEvents { get; set; } = new HashSet<AttendeeEvent>();
        public ICollection<AttendeeEventQuantity> AttendeeEventQuantities { get; set; } = new HashSet<AttendeeEventQuantity>();
        public ICollection<Cost> Costs { get; set; } = new HashSet<Cost>();
        public ICollection<CostDocument> CostDocuments { get; set; } = new HashSet<CostDocument>();
        public ICollection<EventBasicField> EventBasicFields { get; set; } = new HashSet<EventBasicField>();
        public ICollection<EventCostFlexibleField> EventCostFlexibleFields { get; set; } = new HashSet<EventCostFlexibleField>();
        public ICollection<EventCostQuestion> EventCostQuestions { get; set; } = new HashSet<EventCostQuestion>();
        public ICollection<EventTypeQuestion> EventTypeQuestions { get; set; } = new HashSet<EventTypeQuestion>();
        public ICollection<EventUserNotificationHistory> EventUserNotificationHistories { get; set; } = new HashSet<EventUserNotificationHistory>();
        public ICollection<EventUserNotificationRecipient> EventUserNotificationRecipients { get; set; } = new HashSet<EventUserNotificationRecipient>();
        public ICollection<EventWorkflowStep> EventWorkflowSteps { get; set; } = new HashSet<EventWorkflowStep>();
        public ICollection<VipLoungeDurationDate> VipLoungeDurationDates { get; set; } = new HashSet<VipLoungeDurationDate>();
        public Company Company { get; set; }
        public CostCenter CostCenter { get; set; }
        public OrderNumber OrderNumber { get; set; }
        public User User { get; set; }
        public Department Department { get; set; }
        public EventTypeVersion EventTypeVersion { get; set; }
        public User User2 { get; set; }
        public User User1 { get; set; }
        public Event Event2 { get; set; }
        public ICollection<Event> Event1 { get; set; }
        public EventStatuss EventStatuss { get; set; }
        public VipLoungeDurationDate VipLoungeDurationDate { get; set; }
        public ICollection<AttendeePlaceReservation> AttendeePlaceReservations { get; set; } = new HashSet<AttendeePlaceReservation>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasIndex(e => e.FinishDate);

                entity.HasIndex(e => e.ProjectNumber);

                entity.HasIndex(e => new { e.EventNo, e.CompanyID }).IsUnique();

                entity.Property(e => e.Comments).HasMaxLength(500);

                entity.Property(e => e.EventNo)
                    .IsRequired()
                    .HasMaxLength(440);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProjectNumber).HasMaxLength(450);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CompanyID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.CostCenter)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CostCenterID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CreationUserID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.DepartmentID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventTypeVersion)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.EventTypeVersionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User2)
                    .WithMany(p => p.Events2)
                    .HasForeignKey(d => d.LastChangeUserID);

                entity.HasOne(d => d.User1)
                    .WithMany(p => p.Events1)
                    .HasForeignKey(d => d.RepresenterUserID);

                entity.HasOne(d => d.Event2)
                    .WithMany(p => p.Event1)
                    .HasForeignKey(d => d.SourceID);

                entity.HasOne(d => d.EventStatuss)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.StatusID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.VipLoungeDurationDate)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.VipLoungeDurationDateID);

                entity.HasOne(d => d.OrderNumber)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.OrderNumberID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
