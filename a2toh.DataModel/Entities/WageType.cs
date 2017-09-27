using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class WageType : IEntity, IHasId
    {
        public int ID { get; set; }
        public string Code { get; set; }

        public ICollection<WageTypeVersion> WageTypeVersions { get; set; } = new HashSet<WageTypeVersion>();
        public ICollection<WageTypeMapping> WageTypeMappings { get; set; } = new List<WageTypeMapping>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WageType>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
