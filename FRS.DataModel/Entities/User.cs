using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace FRS.DataModel.Entities
{
    public class User : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
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
        public int? RoleId { get; set; }
        public bool UseRemoteDirectory { get; set; }

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
            });
        }
    }
}
