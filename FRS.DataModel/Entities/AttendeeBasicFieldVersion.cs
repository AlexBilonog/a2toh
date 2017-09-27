using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class AttendeeBasicFieldVersion : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int Id { get; set; }
        public int AttendeeBasicFieldId { get; set; }
        public int? BasicFieldDictionaryTypeId { get; set; }
        public int BasicFieldTypeId { get; set; }
        public string Description { get; set; }
        public int EventTypeVersionId { get; set; }
        public bool IsMandatory { get; set; }
        public string Tooltip { get; set; }

        public ICollection<AttendeeEventBasicField> AttendeeEventBasicFields { get; set; } = new HashSet<AttendeeEventBasicField>();
        public AttendeeBasicField AttendeeBasicField { get; set; }
        public BasicFieldDictionaryType BasicFieldDictionaryType { get; set; }
        public BasicFieldType BasicFieldType { get; set; }
        public EventTypeVersion EventTypeVersion { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendeeBasicFieldVersion>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.AttendeeBasicField)
                    .WithMany(p => p.AttendeeBasicFieldVersions)
                    .HasForeignKey(d => d.AttendeeBasicFieldId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.BasicFieldDictionaryType)
                    .WithMany(p => p.AttendeeBasicFieldVersions)
                    .HasForeignKey(d => d.BasicFieldDictionaryTypeId);

                entity.HasOne(d => d.BasicFieldType)
                    .WithMany(p => p.AttendeeBasicFieldVersions)
                    .HasForeignKey(d => d.BasicFieldTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventTypeVersion)
                    .WithMany(p => p.AttendeeBasicFieldVersions)
                    .HasForeignKey(d => d.EventTypeVersionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
