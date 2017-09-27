using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class AgendaWorkingProgramVersion : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int EventTypeVersionId { get; set; }

        public ICollection<Agenda> Agenda { get; set; } = new HashSet<Agenda>();
        public EventTypeVersion EventTypeVersion { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendaWorkingProgramVersion>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.EventTypeVersion)
                    .WithMany(p => p.AgendaWorkingProgramVersions)
                    .HasForeignKey(d => d.EventTypeVersionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
