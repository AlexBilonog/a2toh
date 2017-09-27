using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class CostCategory : IEntity, IHasId
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public ICollection<CostCategoryVersion> CostCategoryVersions { get; set; } = new HashSet<CostCategoryVersion>();
     
        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostCategory>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(100);
            });
        }
    }
}
