using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class CostFlexibleFieldType : IEntity, IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CostFlexibleFieldVersion> CostFlexibleFieldVersions { get; set; } = new HashSet<CostFlexibleFieldVersion>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostFlexibleFieldType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
