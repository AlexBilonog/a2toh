using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public class VipLoungePlace : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int DepartmentId { get; set; }
        public int VipLoungeId { get; set; }

        public ICollection<AttendeePlaceReservation> AttendeePlaceReservations { get; set; } = new HashSet<AttendeePlaceReservation>();
        public VipLounge VipLounge { get; set; }
        public Department Department { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungePlace>(entity =>
            {
                entity.HasOne(d => d.VipLounge)
                    .WithMany(p => p.VipLoungePlaces)
                    .HasForeignKey(d => d.VipLoungeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.VipLoungePlaces)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
