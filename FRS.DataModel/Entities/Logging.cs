using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace FRS.DataModel.Entities
{
    public partial class Logging : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int Id { get; set; }
        public DateTime ActionTime { get; set; }
        public string AdditionalInformation { get; set; }
        public int LoggingActionId { get; set; }
        public int? UserId { get; set; }
        public int? UserRepresenterId { get; set; }

        public LoggingAction LoggingAction { get; set; }
        public User User { get; set; }
        public User User1 { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logging>(entity =>
            {
                entity.Property(e => e.AdditionalInformation).HasMaxLength(1000);

                entity.HasOne(d => d.LoggingAction)
                    .WithMany(p => p.Loggings)
                    .HasForeignKey(d => d.LoggingActionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Loggings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User1)
                    .WithMany(p => p.Loggings1)
                    .HasForeignKey(d => d.UserRepresenterId);
            });
        }
    }
}
