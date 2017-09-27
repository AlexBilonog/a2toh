using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace FRS.DataModel.Entities
{
    public partial class WageTypeTaxationReport : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public bool IsTransferredToPayrollSystem { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WageTypeTaxationReport>(entity =>
            {
            });
        }
    }
}
