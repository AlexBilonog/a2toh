using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace FRS.DataModel.Entities
{
    public partial class ReportDocument : AuditInfo, IEntity, IHasUser, IHasId, IHasDescription
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public DateTime LastChangeDate { get; set; }
        public int LastChangeUserId { get; set; }
        public int Year { get; set; }

        public Company Company { get; set; }
        public ReportDocumentFile ReportDocumentFile { get; set; }
        public User User { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportDocument>(entity =>
            {
                entity.Property(e => e.FileName).IsRequired();

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ReportDocuments)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReportDocuments)
                    .HasForeignKey(d => d.LastChangeUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
