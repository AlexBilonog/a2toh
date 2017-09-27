using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class VipLoungeCostCategory : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public int CostCategoryVersionId { get; set; }
        public decimal? CostSum { get; set; }
        public bool? IsExtraCategory { get; set; }
        public int VipLoungeId { get; set; }

        public CostCategoryVersion CostCategoryVersion { get; set; }  
        public VipLounge VipLounge { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungeCostCategory>(entity =>
            {
                entity.HasOne(d => d.CostCategoryVersion)
                    .WithMany(p => p.VipLoungeCostCategories)
                    .HasForeignKey(d => d.CostCategoryVersionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.VipLounge)
                    .WithMany(p => p.VipLoungeCostCategories)
                    .HasForeignKey(d => d.VipLoungeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
