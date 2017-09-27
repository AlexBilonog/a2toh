using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class CostAllocationStatuss : IEntity, IHasId
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Cost> Costs { get; set; } = new HashSet<Cost>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostAllocationStatuss>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
