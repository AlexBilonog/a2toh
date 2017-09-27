using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FRS.DataModel.Entities
{
    public partial class Season : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Season>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired();
                entity.HasIndex(e => e.Name)
                    .IsUnique();
                entity.HasOne(d => d.Team)
                    .WithMany(d => d.Seasons)
                    .HasForeignKey(d => d.TeamId);
            });
        }
    }
}
