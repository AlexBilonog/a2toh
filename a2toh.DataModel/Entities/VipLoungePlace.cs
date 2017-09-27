using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public class VipLoungePlace : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int DepartmentID { get; set; }
        public int VipLoungeID { get; set; }

        public ICollection<AttendeePlaceReservation> AttendeePlaceReservations { get; set; } = new HashSet<AttendeePlaceReservation>();
        public VipLounge VipLounge { get; set; }
        public Department Department { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungePlace>(entity =>
            {
                entity.HasOne(d => d.VipLounge)
                    .WithMany(p => p.VipLoungePlaces)
                    .HasForeignKey(d => d.VipLoungeID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.VipLoungePlaces)
                    .HasForeignKey(d => d.DepartmentID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
