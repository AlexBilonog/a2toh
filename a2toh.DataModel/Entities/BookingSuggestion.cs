using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EventManager.DataModel.Entities
{
    public partial class BookingSuggestion : IEntity, IHasId
    {
        public int ID { get; set; }
        public string Code { get; set; }

        public ICollection<BookingSuggestionAccountMapping> BookingSuggestionAccountMappings { get; set; } = new HashSet<BookingSuggestionAccountMapping>();
        public ICollection<BookingSuggestionVersion> BookingSuggestionVersions { get; set; } = new HashSet<BookingSuggestionVersion>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingSuggestion>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
