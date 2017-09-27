using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EventManager.DataModel.Entities
{
    public partial class LoggingAction : IEntity, IHasId
    {
        public int ID { get; set; }
        public int? LoggingActionModuleID { get; set; }
        public string Name { get; set; }

        public ICollection<Logging> Loggings { get; set; } = new HashSet<Logging>();
        public LoggingActionModule LoggingActionModule { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoggingAction>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.LoggingActionModule)
                    .WithMany(p => p.LoggingActions)
                    .HasForeignKey(d => d.LoggingActionModuleID);
            });
        }
    }
}
