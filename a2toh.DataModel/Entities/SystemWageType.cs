using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EventManager.DataModel.Entities
{
    public partial class SystemWageType : IEntity, IHasId, IHasDescription
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<WageTypeVersion> WageTypeVersions { get; set; } = new HashSet<WageTypeVersion>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemWageType>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
