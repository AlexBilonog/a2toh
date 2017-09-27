using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class AttendeeType : IEntity, IHasId
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public ICollection<AttendeeTypeVersion> AttendeeTypeVersions { get; set; } = new HashSet<AttendeeTypeVersion>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendeeType>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(100);
            });
        }
    }
}
