using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class DataConditionField : IEntity, IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<DataConditionCriteria> DataConditionCriterias { get; set; } = new HashSet<DataConditionCriteria>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataConditionField>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
