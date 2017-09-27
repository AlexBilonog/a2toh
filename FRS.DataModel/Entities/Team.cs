using System.Collections.Generic;
using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FRS.DataModel.Entities
{
    public partial class Team : AuditInfo, IHasId, IHasActiveState
    {
        public Team()
        {
            IsActive = true;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public ICollection<VipLounge> VipLounges { get; set; } = new HashSet<VipLounge>();
        public ICollection<Season> Seasons { get; set; } = new HashSet<Season>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired();

                entity.HasOne(d => d.Sport)
                    .WithMany()
                    .HasForeignKey(d => d.SportId);
            });
        }
    }
}
