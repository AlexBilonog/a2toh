using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class BasicFieldVersion : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int Id { get; set; }
        public int? BasicFieldDictionaryTypeId { get; set; }
        public int BasicFieldId { get; set; }
        public int BasicFieldTypeId { get; set; }
        public string DefaultValue1 { get; set; }
        public string DefaultValue2 { get; set; }
        public string Description { get; set; }
        public int EventTypeVersionId { get; set; }
        public bool IsMandatory { get; set; }
        public string Tooltip { get; set; }
        public string OptionDescription { get; set; }
        public int OrderNumber { get; set; }

        public ICollection<EventBasicField> EventBasicFields { get; set; } = new HashSet<EventBasicField>();
        public BasicFieldDictionaryType BasicFieldDictionaryType { get; set; }
        public BasicField BasicField { get; set; }
        public BasicFieldType BasicFieldType { get; set; }
        public EventTypeVersion EventTypeVersion { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasicFieldVersion>(entity =>
            {
                entity.Property(e => e.DefaultValue1).HasMaxLength(500);

                entity.Property(e => e.DefaultValue2).HasMaxLength(500);

                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.BasicFieldDictionaryType)
                    .WithMany(p => p.BasicFieldVersions)
                    .HasForeignKey(d => d.BasicFieldDictionaryTypeId);

                entity.HasOne(d => d.BasicField)
                    .WithMany(p => p.BasicFieldVersions)
                    .HasForeignKey(d => d.BasicFieldId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.BasicFieldType)
                    .WithMany(p => p.BasicFieldVersions)
                    .HasForeignKey(d => d.BasicFieldTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventTypeVersion)
                    .WithMany(p => p.BasicFieldVersions)
                    .HasForeignKey(d => d.EventTypeVersionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
