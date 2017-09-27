using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FRS.DataModel.Entities
{
    public partial class CostDocumentFile : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }

        public CostDocument CostDocument { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostDocumentFile>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content).IsRequired();

                entity.HasOne(d => d.CostDocument)
                    .WithOne(p => p.CostDocumentFile)
                    .HasForeignKey<CostDocumentFile>(d => d.Id);
            });
        }
    }
}
