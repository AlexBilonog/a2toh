using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class EventCostFlexibleField : IEntity, IHasId
    {
        public int Id { get; set; }
        public int CostFlexibleFieldVersionId { get; set; }
        public int EventId { get; set; }
        public bool? Value { get; set; }

        public CostFlexibleFieldVersion CostFlexibleFieldVersion { get; set; }
        public Event Event { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventCostFlexibleField>(entity =>
            {
                entity.HasOne(d => d.CostFlexibleFieldVersion)
                    .WithMany(p => p.EventCostFlexibleFields)
                    .HasForeignKey(d => d.CostFlexibleFieldVersionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventCostFlexibleFields)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
