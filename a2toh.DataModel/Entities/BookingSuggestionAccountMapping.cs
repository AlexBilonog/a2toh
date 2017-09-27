using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManager.DataModel.Entities
{
    public partial class BookingSuggestionAccountMapping : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int ID { get; set; }
        public int BookingSuggestionID { get; set; }
        public string Description { get; set; }
        public int EventTypeID { get; set; }
        public string MappedAccount { get; set; }

        public BookingSuggestion BookingSuggestion { get; set; }
        public EventType EventType { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingSuggestionAccountMapping>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(440);

                entity.Property(e => e.MappedAccount)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.BookingSuggestion)
                    .WithMany(p => p.BookingSuggestionAccountMappings)
                    .HasForeignKey(d => d.BookingSuggestionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.BookingSuggestionAccountMappings)
                    .HasForeignKey(d => d.EventTypeID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
