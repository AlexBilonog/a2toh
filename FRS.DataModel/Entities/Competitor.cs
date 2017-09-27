using System;
using System.Collections.Generic;
using FRS.Common.Contracts;
using FRS.DataModel.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class Competitor : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int SeasonId { get; set; }
        public int TournamentId { get; set; }

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
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
