using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class AttendeeHistory : AuditInfo, IEntity, IHasActiveState, IHasId
    {
        public int Id { get; set; }
        public int AttendeeAccessoryId { get; set; }
        public int AttendeeId { get; set; }
        public int? AttendeeSalutationId { get; set; }
        public DateTime? Birthday { get; set; }
        public int? CompanyId { get; set; }
        public int? DepartmentId { get; set; }
        public string Email { get; set; }
        public string ExternalCompany { get; set; }
        public string ExternalDepartment { get; set; }
        public string FirstName { get; set; }
        public bool IsActive { get; set; }
        public bool IsInvitedPerson { get; set; }
        public bool IsManual { get; set; }
        public bool IsTechnicalRewriting { get; set; }
        public bool IsTemporaryWorker { get; set; }
        public string LastName { get; set; }
        public int? ParentAttendeeId { get; set; }
        public string PersonalNo { get; set; }
        public int TaxationId { get; set; }
        public string Title { get; set; }
        public string Supervisor { get; set; }
        public DateTime ValidFrom { get; set; }

        public ICollection<AttendeeEvent> AttendeeEvents { get; set; } = new HashSet<AttendeeEvent>();
        public AttendeeAccessory AttendeeAccessory { get; set; }
        public Attendee Attendee { get; set; }
        public AttendeeSalutation AttendeeSalutation { get; set; }
        public Company Company { get; set; }
        public Department Department { get; set; }
        public Attendee Attendee1 { get; set; }
        public Taxation Taxation { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendeeHistory>(entity =>
            {
                entity.HasIndex(e => e.Email);

                entity.HasIndex(e => e.FirstName);

                entity.HasIndex(e => e.IsInvitedPerson);

                entity.HasIndex(e => e.LastName);

                entity.HasIndex(e => e.PersonalNo);

                entity.HasIndex(e => e.ValidFrom);

                entity.Property(e => e.Email).HasMaxLength(450);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.PersonalNo).HasMaxLength(450);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.AttendeeAccessory)
                    .WithMany(p => p.AttendeeHistories)
                    .HasForeignKey(d => d.AttendeeAccessoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Attendee)
                    .WithMany(p => p.AttendeeHistories)
                    .HasForeignKey(d => d.AttendeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.AttendeeSalutation)
                    .WithMany(p => p.AttendeeHistories)
                    .HasForeignKey(d => d.AttendeeSalutationId);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.AttendeeHistories)
                    .HasForeignKey(d => d.CompanyId);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.AttendeeHistories)
                    .HasForeignKey(d => d.DepartmentId);

                entity.HasOne(d => d.Attendee1)
                    .WithMany(p => p.AttendeeHistories1)
                    .HasForeignKey(d => d.ParentAttendeeId);

                entity.HasOne(d => d.Taxation)
                    .WithMany(p => p.AttendeeHistories)
                    .HasForeignKey(d => d.TaxationId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
