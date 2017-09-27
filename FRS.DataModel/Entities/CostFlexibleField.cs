using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class CostFlexibleField : IEntity, IHasId
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public ICollection<CostFlexibleFieldVersion> CostFlexibleFieldVersions { get; set; } = new HashSet<CostFlexibleFieldVersion>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostFlexibleField>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
