using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventManager.DataModel.Entities
{
    public partial class SocialSecurityReport : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int CompanyID { get; set; }
        public bool IsTransferredToPayrollSystem { get; set; }

        public Company Company { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SocialSecurityReport>(entity =>
            {
                entity.HasOne(d => d.Company)
                    .WithMany(p => p.SocialSecurityReports)
                    .HasForeignKey(d => d.CompanyID);
            });
        }
    }
}
