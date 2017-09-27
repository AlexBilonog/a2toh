using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class VipLounge : AuditInfo, IEntity, IHasId, IHasDescription
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int EventTypeId { get; set; }
        public int? EventTypeVersionId { get; set; }
        public bool IsReleased { get; set; }
        public string Name { get; set; }
        public int SeatsNumber { get; set; }
        public decimal OrganizerRatio { get; set; }
        public decimal Deduction { get; set; }
        public decimal Netto { get; set; }
        public decimal Brutto { get; set; }
        public decimal AvailableNettoSum { get; set; }
        public int? TaxCodeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? TeamId { get; set; }
        public int? SportId { get; set; }
        public int? CompanyId { get; set; }
        public int? CostCenterId { get; set; }
        public string CostCenterText { get; set; }
        public int? OrderNumberId { get; set; }
        public string OrderNumberText { get; set; }
        public bool IsEventDatesInitiallyImported { get; set; }
        public int? SeasonId { get; set; }
        public int? SourceVipLoungeId { get; set; }
        public bool HasAutoCopy { get; set; }
        public int? ResponsibleUserId { get; set; }

        public ICollection<VipLounge> ChildVipLounges { get; set; } = new HashSet<VipLounge>();
        public ICollection<VipLoungeCostCategory> VipLoungeCostCategories { get; set; } = new HashSet<VipLoungeCostCategory>();
        public ICollection<VipLoungeCostFlexibleField> VipLoungeCostFlexibleFields { get; set; } = new HashSet<VipLoungeCostFlexibleField>();
        public ICollection<VipLoungeCostQuestion> VipLoungeCostQuestions { get; set; } = new HashSet<VipLoungeCostQuestion>();
        public ICollection<VipLoungeDeclarationDate> VipLoungeDeclarationDates { get; set; } = new HashSet<VipLoungeDeclarationDate>();
        public ICollection<VipLoungeDocument> VipLoungeDocuments { get; set; } = new HashSet<VipLoungeDocument>();
        public ICollection<VipLoungeDurationDate> VipLoungeDurationDates { get; set; } = new HashSet<VipLoungeDurationDate>();
        public ICollection<VipLoungeUserNotification> VipLoungeUserNotifications { get; set; } = new HashSet<VipLoungeUserNotification>();
        public ICollection<VipLoungePlace> VipLoungePlaces { get; set; } = new HashSet<VipLoungePlace>();
        public EventType EventType { get; set; }
        public EventTypeVersion EventTypeVersion { get; set; }
        public TaxCode TaxCode { get; set; }
        public Department Department { get; set; }
        public Team Team { get; set; }
        public Sport Sport { get; set; }
        public Company Company { get; set; }
        public CostCenter CostCenter { get; set; }
        public OrderNumber OrderNumber { get; set; }
        public Season Season { get; set; }
        public VipLounge SourceVipLounge { get; set; }
        public User ResponsibleUser { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLounge>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(e => e.Name).IsUnique();

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.VipLounges)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.EventTypeVersion)
                    .WithMany(p => p.VipLounges)
                    .HasForeignKey(d => d.EventTypeVersionId);

                entity.HasOne(d => d.TaxCode)
                    .WithMany(p => p.VipLounges)
                    .HasForeignKey(d => d.TaxCodeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.VipLounges)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.VipLounges)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Sport)
                    .WithMany()
                    .HasForeignKey(d => d.SportId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Company)
                    .WithMany()
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.CostCenter)
                    .WithMany(p => p.VipLounges)
                    .HasForeignKey(d => d.CostCenterId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.OrderNumber)
                    .WithMany(p => p.VipLounges)
                    .HasForeignKey(d => d.OrderNumberId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Season)
                    .WithMany()
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.SourceVipLounge)
                    .WithMany(d => d.ChildVipLounges)
                    .HasForeignKey(d => d.SourceVipLoungeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ResponsibleUser)
                    .WithMany()
                    .HasForeignKey(d => d.ResponsibleUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
