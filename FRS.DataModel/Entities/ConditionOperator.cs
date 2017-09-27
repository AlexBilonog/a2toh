using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class ConditionOperator : IEntity, IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<DataConditionCriteria> DataConditionCriterias { get; set; } = new HashSet<DataConditionCriteria>();
        public ICollection<StepSkipConditionCriteria> StepSkipConditionCriterias { get; set; } = new HashSet<StepSkipConditionCriteria>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConditionOperator>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });
        }
    }
}
