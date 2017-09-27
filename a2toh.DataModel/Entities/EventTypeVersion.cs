using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class EventTypeVersion : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int ID { get; set; }
        public TimeSpan AgendaCoreFromTime { get; set; }
        public TimeSpan AgendaCoreToTime { get; set; }
        public string Description { get; set; }
        public int EventTypeID { get; set; }
        public int EventTypeVersionFileID { get; set; }
        public string EventUpdateDescription { get; set; }
        public byte EventUpdateType { get; set; }
        public DateTime ImportDate { get; set; }
        public bool IsActualAttendeesByQuantityAllowed { get; set; }
        public bool IsAgendaAllowed { get; set; }
        public bool IsAttendeeExtraFieldsAllowed { get; set; }
        public bool IsBookingSuggestionPhaseAllowed { get; set; }
        public bool IsChangesAllowed { get; set; }
        public bool IsCorporateEvent { get; set; }
        public bool IsCostQuestionsChanged { get; set; }
        public bool IsEventTypeDecisionTreeChanged { get; set; }
        public bool IsPlannedAttendeesByQuantityAllowed { get; set; }
        public bool IsGiftAllocationAllowed { get; set; }
        public bool IsVipLoungeAllowed { get; set; }
        public string Name { get; set; }
        public DateTime ValidFrom { get; set; }
        public string Version { get; set; }
        public bool IsCopyCostsToActualPhase { get; set; }

        public ICollection<AgendaCommonProgramVersion> AgendaCommonProgramVersions { get; set; } = new HashSet<AgendaCommonProgramVersion>();
        public ICollection<AgendaOtherProgramVersion> AgendaOtherProgramVersions { get; set; } = new HashSet<AgendaOtherProgramVersion>();
        public ICollection<AgendaWorkingProgramVersion> AgendaWorkingProgramVersions { get; set; } = new HashSet<AgendaWorkingProgramVersion>();
        public ICollection<AttendeeBasicFieldVersion> AttendeeBasicFieldVersions { get; set; } = new HashSet<AttendeeBasicFieldVersion>();
        public ICollection<AttendeeTypeVersion> AttendeeTypeVersions { get; set; } = new HashSet<AttendeeTypeVersion>();
        public ICollection<BasicFieldVersion> BasicFieldVersions { get; set; } = new HashSet<BasicFieldVersion>();
        public ICollection<BookingSuggestionVersion> BookingSuggestionVersions { get; set; } = new HashSet<BookingSuggestionVersion>();
        public ICollection<CostCategoryVersion> CostCategoryVersions { get; set; } = new HashSet<CostCategoryVersion>();
        public ICollection<CostFlexibleFieldVersion> CostFlexibleFieldVersions { get; set; } = new HashSet<CostFlexibleFieldVersion>();
        public ICollection<CostQuestionVersion> CostQuestionVersions { get; set; } = new HashSet<CostQuestionVersion>();
        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
        public ICollection<VipLounge> VipLounges { get; set; } = new HashSet<VipLounge>();
        public ICollection<WageTypeVersion> WageTypeVersions { get; set; } = new HashSet<WageTypeVersion>();
        public EventType EventType { get; set; }
        public EventTypeVersionFile EventTypeVersionFile { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventTypeVersion>(entity =>
            {
                entity.HasIndex(e => e.ValidFrom);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(3000);

                entity.Property(e => e.EventUpdateDescription).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.EventTypeVersions)
                    .HasForeignKey(d => d.EventTypeID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventTypeVersionFile)
                    .WithMany(p => p.EventTypeVersions)
                    .HasForeignKey(d => d.EventTypeVersionFileID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
