using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class CostCenter : AuditInfo, IEntity, IHasActiveState, IHasId, IHasDescription
    {
        public CostCenter()
        {
            IsActive = true;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }

        public ICollection<AttendeeEvent> AttendeeEvents { get; set; } = new HashSet<AttendeeEvent>();
        public ICollection<Event> Events { get; set; } = new HashSet<Event>();
        public ICollection<Gift> Gifts { get; set; } = new HashSet<Gift>();
        public ICollection<VipLounge> VipLounges { get; set; } = new HashSet<VipLounge>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostCenter>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasIndex(e => e.Name).IsUnique();
            });
        }
    }
}
