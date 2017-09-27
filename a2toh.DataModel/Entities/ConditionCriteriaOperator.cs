using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EventManager.DataModel.Entities
{
    public partial class ConditionCriteriaOperator : IEntity, IHasId
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<DataConditionCriteria> DataConditionCriterias { get; set; } = new HashSet<DataConditionCriteria>();
        public ICollection<StepSkipConditionCriteria> StepSkipConditionCriterias { get; set; } = new HashSet<StepSkipConditionCriteria>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConditionCriteriaOperator>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
