using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class EventTypeVersionFile : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public byte[] Content { get; set; }

        public ICollection<EventTypeVersion> EventTypeVersions { get; set; } = new HashSet<EventTypeVersion>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventTypeVersionFile>(entity =>
            {
                entity.Property(e => e.Content).IsRequired();
            });
        }
    }
}
