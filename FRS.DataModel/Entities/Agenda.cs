using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace FRS.DataModel.Entities
{
    public partial class Agenda : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public int? AgendaCommonProgramVersionID { get; set; }
        public int? AgendaOtherProgramVersionID { get; set; }
        public int? AgendaWorkingProgramVersionID { get; set; }
        public string Content { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public int EventID { get; set; }
        public bool IsPlanned { get; set; }
        public int Position { get; set; }

        public AgendaCommonProgramVersion AgendaCommonProgramVersion { get; set; }
        public AgendaOtherProgramVersion AgendaOtherProgramVersion { get; set; }
        public AgendaWorkingProgramVersion AgendaWorkingProgramVersion { get; set; }
        public Event Event { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agenda>(entity =>
            {
                entity.Property(e => e.Content).IsRequired();

                entity.HasOne(d => d.AgendaCommonProgramVersion)
                    .WithMany(p => p.Agenda)
                    .HasForeignKey(d => d.AgendaCommonProgramVersionID);

                entity.HasOne(d => d.AgendaOtherProgramVersion)
                    .WithMany(p => p.Agenda)
                    .HasForeignKey(d => d.AgendaOtherProgramVersionID);

                entity.HasOne(d => d.AgendaWorkingProgramVersion)
                    .WithMany(p => p.Agenda)
                    .HasForeignKey(d => d.AgendaWorkingProgramVersionID);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Agenda)
                    .HasForeignKey(d => d.EventID).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
