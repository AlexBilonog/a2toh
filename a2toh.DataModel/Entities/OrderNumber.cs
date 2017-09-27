using System.Collections.Generic;
using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DataModel.Entities
{
    public partial class OrderNumber : AuditInfo, IHasId, IHasActiveState
    {
        public OrderNumber()
        {
            IsActive = true;
        }
        public int ID { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ICollection<VipLounge> VipLounges { get; set; } = new HashSet<VipLounge>();
        public ICollection<Event> Events { get; set; } = new HashSet<Event>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderNumber>(entity =>
            {
                entity.Property(e => e.Number)
                    .IsRequired();
                entity.HasIndex(e => e.Number)
                    .IsUnique();
            });
        }
    }
}
