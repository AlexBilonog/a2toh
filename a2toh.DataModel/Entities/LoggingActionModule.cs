using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class LoggingActionModule : IEntity, IHasId
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<LoggingAction> LoggingActions { get; set; } = new HashSet<LoggingAction>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoggingActionModule>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
