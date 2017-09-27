using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EventManager.DataModel.Entities
{
    public partial class BasicFieldDictionaryType : IEntity, IHasId
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<AttendeeBasicFieldVersion> AttendeeBasicFieldVersions { get; set; } = new HashSet<AttendeeBasicFieldVersion>();
        public ICollection<BasicFieldVersion> BasicFieldVersions { get; set; } = new HashSet<BasicFieldVersion>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasicFieldDictionaryType>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
