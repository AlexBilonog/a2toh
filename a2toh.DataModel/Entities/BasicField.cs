using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EventManager.DataModel.Entities
{
    public partial class BasicField : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public string Code { get; set; }

        public ICollection<BasicFieldVersion> BasicFieldVersions { get; set; } = new HashSet<BasicFieldVersion>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasicField>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
