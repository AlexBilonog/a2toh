using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class StepSkipCondition : IEntity, IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<StepSkipConditionCriteria> StepSkipConditionCriterias { get; set; } = new HashSet<StepSkipConditionCriteria>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StepSkipCondition>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
