using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class VipLoungeDeclarationDate : AuditInfo, IEntity, IHasUser, IHasId, IHasDescription
    {
        public int ID { get; set; }
        public int CreationUserID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int VipLoungeID { get; set; }

        public ICollection<VipLoungeDeclarationDateUserNotification> VipLoungeDeclarationDateUserNotifications { get; set; } = new HashSet<VipLoungeDeclarationDateUserNotification>();
        public ICollection<VipLoungeDurationDate> VipLoungeDurationDates { get; set; } = new HashSet<VipLoungeDurationDate>();
        public User User { get; set; }
        public VipLounge VipLounge { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungeDeclarationDate>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VipLoungeDeclarationDates)
                    .HasForeignKey(d => d.CreationUserID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.VipLounge)
                    .WithMany(p => p.VipLoungeDeclarationDates)
                    .HasForeignKey(d => d.VipLoungeID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
