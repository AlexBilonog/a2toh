using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class LoggingAction : IEntity, IHasId
    {
        public int Id { get; set; }
        public int? LoggingActionModuleId { get; set; }
        public string Name { get; set; }

        public ICollection<Logging> Loggings { get; set; } = new HashSet<Logging>();
        public LoggingActionModule LoggingActionModule { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoggingAction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.LoggingActionModule)
                    .WithMany(p => p.LoggingActions)
                    .HasForeignKey(d => d.LoggingActionModuleId);
            });
        }
    }
}
