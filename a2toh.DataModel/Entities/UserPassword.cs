using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace FRS.DataModel.Entities
{
    public partial class UserPassword : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public DateTime? SetPasswordDateTime { get; set; }
        public int? UserID { get; set; }

        public User User { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPassword>(entity =>
            {
                entity.Property(e => e.Password).HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPasswords)
                    .HasForeignKey(d => d.UserID);
            });
        }
    }
}
