using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class BasicFieldVersion : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int ID { get; set; }
        public int? BasicFieldDictionaryTypeID { get; set; }
        public int BasicFieldID { get; set; }
        public int BasicFieldTypeID { get; set; }
        public string DefaultValue1 { get; set; }
        public string DefaultValue2 { get; set; }
        public string Description { get; set; }
        public int EventTypeVersionID { get; set; }
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
                    .HasForeignKey(d => d.BasicFieldDictionaryTypeID);

                entity.HasOne(d => d.BasicField)
                    .WithMany(p => p.BasicFieldVersions)
                    .HasForeignKey(d => d.BasicFieldID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.BasicFieldType)
                    .WithMany(p => p.BasicFieldVersions)
                    .HasForeignKey(d => d.BasicFieldTypeID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventTypeVersion)
                    .WithMany(p => p.BasicFieldVersions)
                    .HasForeignKey(d => d.EventTypeVersionID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
