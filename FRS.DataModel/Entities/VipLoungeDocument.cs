using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace FRS.DataModel.Entities
{
    public partial class VipLoungeDocument : AuditInfo, IEntity, IHasUser, IHasId, IHasDescription
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
        public string Keywords { get; set; }
        public DateTime LastChangeDate { get; set; }
        public int LastChangeUserID { get; set; }
        public int VipLoungeID { get; set; }

        public VipLoungeDocumentFile VipLoungeDocumentFile { get; set; }
        public User User { get; set; }
        public VipLounge VipLounge { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungeDocument>(entity =>
            {
                entity.Property(e => e.FileName).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.VipLoungeDocuments)
                    .HasForeignKey(d => d.LastChangeUserID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.VipLounge)
                    .WithMany(p => p.VipLoungeDocuments)
                    .HasForeignKey(d => d.VipLoungeID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}