using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace FRS.DataModel.Entities
{
    public partial class Limit10KEuroReport : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
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
