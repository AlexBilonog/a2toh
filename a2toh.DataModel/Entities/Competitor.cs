using System;
using System.Collections.Generic;
using EventManager.Common.Contracts;
using EventManager.DataModel.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManager.DataModel.Entities
{
    public partial class Competitor : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int SeasonId { get; set; }
        public int TournamentID { get; set; }

        public Season Season { get; set; }
        public Tournament Tournament { get; set; }
        public ICollection<VipLoungeDurationDate> VipLoungeDurationDates { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competitor>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired();

                entity.HasOne(d => d.Season)
                    .WithMany()
                    .HasForeignKey(d => d.SeasonId);

                entity.HasIndex(e => new { e.SeasonId, e.Name, e.Date})
                    .IsUnique();

                entity.HasOne(d => d.Tournament)
                    .WithMany()
                    .HasForeignKey(d => d.TournamentID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
