using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class WorkflowStepType : IEntity, IHasId
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<WorkflowStep> WorkflowSteps { get; set; } = new HashSet<WorkflowStep>();
        public ICollection<WorkflowStepTypeAction> WorkflowStepTypeActions { get; set; } = new HashSet<WorkflowStepTypeAction>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkflowStepType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
