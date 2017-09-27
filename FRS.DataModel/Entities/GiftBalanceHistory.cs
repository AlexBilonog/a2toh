using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace FRS.DataModel.Entities
{
    public partial class GiftBalanceHistory : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public int GiftID { get; set; }
        public int ClosingBalanceCalculated { get; set; }
        public int Difference { get; set; }
        public string Comment { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }

        public Gift Gift { get; set; }
        public User User { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GiftBalanceHistory>(entity =>
            {
                entity.HasOne(d => d.Gift)
                    .WithMany()
                    .HasForeignKey(d => d.GiftID);

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserID);
            });
        }
    }
}
