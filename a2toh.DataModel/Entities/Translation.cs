using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DataModel.Entities
{
    public partial class Translation : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public bool IsHidden { get; set; }
        public string Key { get; set; }
        public string LanguageCode { get; set; }
        public string Value { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Translation>(entity =>
            {
                entity.HasIndex(e => new { e.Key, e.LanguageCode })
                    .IsUnique();

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(440);

                entity.Property(e => e.LanguageCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Value).HasMaxLength(1000);
            });
        }
    }
}
