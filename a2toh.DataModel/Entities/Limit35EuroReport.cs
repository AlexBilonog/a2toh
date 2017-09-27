using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventManager.DataModel.Entities
{
    public partial class Limit35EuroReport : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public bool IsProcessed { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Limit35EuroReport>(entity =>
            {
            });
        }
    }
}
