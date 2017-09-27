using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class SystemCostCategory : IEntity, IHasId, IHasDescription
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<CostCategoryVersion> CostCategoryVersions { get; set; } = new HashSet<CostCategoryVersion>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemCostCategory>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
