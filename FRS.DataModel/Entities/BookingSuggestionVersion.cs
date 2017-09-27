using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class BookingSuggestionVersion : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int Id { get; set; }
        public int BookingSuggestionId { get; set; }
        public string Description { get; set; }
        public int EventTypeVersionId { get; set; }
        public bool IsTaxDeduct { get; set; }

        public BookingSuggestion BookingSuggestion { get; set; }
        public EventTypeVersion EventTypeVersion { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingSuggestionVersion>(entity =>
            {
                entity.HasOne(d => d.BookingSuggestion)
                    .WithMany(p => p.BookingSuggestionVersions)
                    .HasForeignKey(d => d.BookingSuggestionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventTypeVersion)
                    .WithMany(p => p.BookingSuggestionVersions)
                    .HasForeignKey(d => d.EventTypeVersionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
