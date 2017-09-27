using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DataModel.Entities
{
    public partial class VipLoungeDocumentFile : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public byte[] Content { get; set; }

        public VipLoungeDocument VipLoungeDocument { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungeDocumentFile>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Content).IsRequired();

                entity.HasOne(d => d.VipLoungeDocument)
                    .WithOne(p => p.VipLoungeDocumentFile)
                    .HasForeignKey<VipLoungeDocumentFile>(d => d.ID);
            });
        }
    }
}
