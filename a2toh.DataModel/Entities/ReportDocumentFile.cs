using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DataModel.Entities
{
    public partial class ReportDocumentFile : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public byte[] Content { get; set; }

        public ReportDocument ReportDocument { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportDocumentFile>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Content).IsRequired();

                entity.HasOne(d => d.ReportDocument)
                    .WithOne(p => p.ReportDocumentFile)
                    .HasForeignKey<ReportDocumentFile>(d => d.ID);
            });
        }
    }
}
