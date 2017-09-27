using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManager.DataModel.Entities
{
    public partial class EventCostFlexibleField : IEntity, IHasId
    {
        public int ID { get; set; }
        public int CostFlexibleFieldVersionID { get; set; }
        public int EventID { get; set; }
        public bool? Value { get; set; }

        public CostFlexibleFieldVersion CostFlexibleFieldVersion { get; set; }
        public Event Event { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCostFlexibleField>(entity =>
            {
                entity.HasOne(d => d.CostFlexibleFieldVersion)
                    .WithMany(p => p.EventCostFlexibleFields)
                    .HasForeignKey(d => d.CostFlexibleFieldVersionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventCostFlexibleFields)
                    .HasForeignKey(d => d.EventID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
