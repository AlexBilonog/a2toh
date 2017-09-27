using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FRS.DataModel.Entities
{
    public partial class ReportDocumentFile : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }

        public ReportDocument ReportDocument { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportDocumentFile>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content).IsRequired();

                entity.HasOne(d => d.ReportDocument)
                    .WithOne(p => p.ReportDocumentFile)
                    .HasForeignKey<ReportDocumentFile>(d => d.Id);
            });
        }
    }
}
