using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class AttendeeSalutation : IEntity, IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AttendeeHistory> AttendeeHistories { get; set; } = new HashSet<AttendeeHistory>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendeeSalutation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
