using EventManager.Common.Contracts;
using EventManager.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace EventManager.DataModel.Entities
{
    public partial class CostDocument : AuditInfo, IEntity, IHasUser, IHasId, IHasDescription
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public int EventID { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
        public bool IsPlanned { get; set; }
        public string Keywords { get; set; }
        public DateTime LastChangeDate { get; set; }
        public int LastChangeUserID { get; set; }

        public CostDocumentFile CostDocumentFile { get; set; }
        public Event Event { get; set; }
        public User User { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostDocument>(entity =>
            {
                entity.Property(e => e.FileName).IsRequired();

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.CostDocuments)
                    .HasForeignKey(d => d.EventID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CostDocuments)
                    .HasForeignKey(d => d.LastChangeUserID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
