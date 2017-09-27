using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DataModel.Entities
{
    public partial class CostDocumentFile : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public byte[] Content { get; set; }

        public CostDocument CostDocument { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostDocumentFile>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Content).IsRequired();

                entity.HasOne(d => d.CostDocument)
                    .WithOne(p => p.CostDocumentFile)
                    .HasForeignKey<CostDocumentFile>(d => d.ID);
            });
        }
    }
}
