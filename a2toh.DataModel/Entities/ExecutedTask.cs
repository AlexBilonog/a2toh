using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace FRS.DataModel.Entities
{
    public partial class ExecutedTask : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public DateTime ExecutionTime { get; set; }
        public int TaskTypeID { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExecutedTask>(entity =>
            {
            });
        }
    }
}
