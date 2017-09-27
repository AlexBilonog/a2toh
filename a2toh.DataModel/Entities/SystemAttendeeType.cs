using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class SystemAttendeeType : IEntity, IHasId, IHasDescription
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<AttendeeTypeVersion> AttendeeTypeVersions { get; set; } = new HashSet<AttendeeTypeVersion>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemAttendeeType>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
