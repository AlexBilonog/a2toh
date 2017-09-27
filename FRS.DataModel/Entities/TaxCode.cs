using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class TaxCode : AuditInfo, IEntity, IHasDescription, IHasId
    {
        public int ID { get; set; }
        public string Account { get; set; }
        public int Category { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime ValidFromDate { get; set; }
        public DateTime ValidToDate { get; set; }
        public decimal Rate { get; set; }
        public int? TaxCode2ID { get; set; }

        public ICollection<Cost> Costs { get; set; } = new HashSet<Cost>();
        public ICollection<VipLounge> VipLounges { get; set; } = new HashSet<VipLounge>();
        public ICollection<TaxCode> TaxCodes1 { get; set; } = new HashSet<TaxCode>();
        public TaxCode TaxCode2 { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxCode>(entity =>
            {
                entity.Property(e => e.Account).HasMaxLength(20);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasIndex(e => e.Code).IsUnique();

                entity.Property(e => e.Description).HasMaxLength(450);

                entity.HasIndex(e => e.Description).IsUnique();

                entity.HasOne(d => d.TaxCode2)
                    .WithMany(p => p.TaxCodes1)
                    .HasForeignKey(d => d.TaxCode2ID);
            });
        }
    }
}
