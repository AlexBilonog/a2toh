using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace FRS.DataModel.Entities
{
    public class License : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public string Value { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string AdditionalInformation { get; set; }
        public int UserId { get; set; }
        public bool IsDemo { get; set; }

        public User User { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<License>(entity =>
            {
                entity.Property(e => e.Value).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId);
            });
        }
    }
}
