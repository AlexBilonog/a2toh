using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace FRS.DataModel.Entities
{
    public partial class ExecutedTask : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public DateTime ExecutionTime { get; set; }
        public int TaskTypeId { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExecutedTask>(entity =>
            {
            });
        }
    }
}
