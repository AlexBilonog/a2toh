using EventManager.Common.Contracts;
using EventManager.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace EventManager.DataModel.Entities
{
    public partial class Logging : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int ID { get; set; }
        public DateTime ActionTime { get; set; }
        public string AdditionalInformation { get; set; }
        public int LoggingActionID { get; set; }
        public int? UserID { get; set; }
        public int? UserRepresenterID { get; set; }

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
                    .HasForeignKey(d => d.LoggingActionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Loggings)
                    .HasForeignKey(d => d.UserID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User1)
                    .WithMany(p => p.Loggings1)
                    .HasForeignKey(d => d.UserRepresenterID);
            });
        }
    }
}
