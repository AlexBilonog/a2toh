using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace FRS.DataModel.Entities
{
    public partial class RepresentativePerson : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int Id { get; set; }
        public DateTime AssignmentDate { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public bool IsInactive { get; set; }
        public bool IsPassive { get; set; }
        public int RepresentedUserId { get; set; }
        public int RepresenterUserId { get; set; }

        public User User { get; set; }
        public User User1 { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RepresentativePerson>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.RepresentativePersons)
                    .HasForeignKey(d => d.RepresentedUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User1)
                    .WithMany(p => p.RepresentativePersons1)
                    .HasForeignKey(d => d.RepresenterUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
