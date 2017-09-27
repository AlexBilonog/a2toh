using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class Attendee : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public DateTime? ValidTo { get; set; }

        public ICollection<AttendeeHistory> AttendeeHistories { get; set; } = new HashSet<AttendeeHistory>();
        public ICollection<AttendeeHistory> AttendeeHistories1 { get; set; } = new HashSet<AttendeeHistory>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>(entity =>
            {
            });
        }
    }
}
