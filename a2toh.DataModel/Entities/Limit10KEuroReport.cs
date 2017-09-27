using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventManager.DataModel.Entities
{
    public partial class Limit10KEuroReport : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public bool IsProcessed { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Limit10KEuroReport>(entity =>
            {
            });
        }
    }
}
