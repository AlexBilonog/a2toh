using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class User : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public int? InvalidLoginAttemptsCount { get; set; }
        public bool IsLocked { get; set; }
        public bool? IsNew { get; set; }
        public bool IsRemoved { get; set; }
        public string LanguageCulture { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordLastChangedDate { get; set; }
        public string Phone { get; set; }
        public string RemoteUserName { get; set; }
        public string ResetPasswordHash { get; set; }
        public DateTime? ResetPasswordSendDateTime { get; set; }
        public int? RoleID { get; set; }
        public bool UseRemoteDirectory { get; set; }

        public ICollection<CostAllocationUserNotificationRecipient> CostAllocationUserNotificationRecipients { get; set; } = new HashSet<CostAllocationUserNotificationRecipient>();
        public ICollection<CostDocument> CostDocuments { get; set; } = new HashSet<CostDocument>();
        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
        public ICollection<Event> Events2 { get; set; } = new HashSet<Event>();
        public ICollection<Event> Events1 { get; set; } = new HashSet<Event>();
        public ICollection<EventUserNotificationHistory> EventUserNotificationHistories { get; set; } = new HashSet<EventUserNotificationHistory>();
        public ICollection<EventUserNotificationHistory> EventUserNotificationHistories1 { get; set; } = new HashSet<EventUserNotificationHistory>();
        public ICollection<EventUserNotificationRecipient> EventUserNotificationRecipients { get; set; } = new HashSet<EventUserNotificationRecipient>();
        public ICollection<EventWorkflowStep> EventWorkflowSteps { get; set; } = new HashSet<EventWorkflowStep>();
        public ICollection<EventWorkflowStepHistory> EventWorkflowStepHistories { get; set; } = new HashSet<EventWorkflowStepHistory>();
        public ICollection<EventWorkflowStepHistory> EventWorkflowStepHistories1 { get; set; } = new HashSet<EventWorkflowStepHistory>();
        public ICollection<Logging> Loggings { get; set; } = new HashSet<Logging>();
        public ICollection<Logging> Loggings1 { get; set; } = new HashSet<Logging>();
        public ICollection<ReportDocument> ReportDocuments { get; set; } = new HashSet<ReportDocument>();
        public ICollection<RepresentativePerson> RepresentativePersons { get; set; } = new HashSet<RepresentativePerson>();
        public ICollection<RepresentativePerson> RepresentativePersons1 { get; set; } = new HashSet<RepresentativePerson>();
        public ICollection<UserDepartment> UserDepartments { get; set; } = new HashSet<UserDepartment>();
        public ICollection<UserPassword> UserPasswords { get; set; } = new HashSet<UserPassword>();
        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
        public ICollection<VipLoungeDeclarationDate> VipLoungeDeclarationDates { get; set; } = new HashSet<VipLoungeDeclarationDate>();
        public ICollection<VipLoungeDeclarationDateUserNotification> VipLoungeDeclarationDateUserNotifications { get; set; } = new HashSet<VipLoungeDeclarationDateUserNotification>();
        public ICollection<VipLoungeDocument> VipLoungeDocuments { get; set; } = new HashSet<VipLoungeDocument>();
        public ICollection<VipLoungeUserNotification> VipLoungeUserNotifications { get; set; } = new HashSet<VipLoungeUserNotification>();
        public ICollection<Gift> Gifts { get; set; } = new HashSet<Gift>();
        public Role Role { get; set; }

        public string UserName
        {
            get { return FirstName + " " + LastName; }
        }

        public string UserNameWithEmail
        {
            get { return UserName + " " + Email; }
        }

        public bool HasChangedPassword { get; set; }
        public bool ClearInvalidLoginAttemptsCount { get; set; }
        public string RandomPassword { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();

                entity.HasIndex(e => e.RemoteUserName).IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LanguageCulture).HasMaxLength(16);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(100);

                entity.Property(e => e.RemoteUserName).HasMaxLength(450);

                entity.Property(e => e.ResetPasswordHash).HasMaxLength(100);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleID);

                //Ignore:
                entity.Ignore(e => e.HasChangedPassword);

                entity.Ignore(e => e.ClearInvalidLoginAttemptsCount);

                entity.Ignore(e => e.RandomPassword);

                entity.Ignore(e => e.UserName);

                entity.Ignore(e => e.UserNameWithEmail);
            });
        }
    }
}
