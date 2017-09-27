using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EventManager.DataModel.Entities
{
    public partial class AttendeeBasicField : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public string Code { get; set; }

        public ICollection<AttendeeBasicFieldVersion> AttendeeBasicFieldVersions { get; set; } = new HashSet<AttendeeBasicFieldVersion>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendeeBasicField>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
