using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManager.DataModel.Entities
{
    public partial class VipLoungeCostCategory : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public int CostCategoryVersionID { get; set; }
        public decimal? CostSum { get; set; }
        public bool? IsExtraCategory { get; set; }
        public int VipLoungeID { get; set; }

        public CostCategoryVersion CostCategoryVersion { get; set; }  
        public VipLounge VipLounge { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungeCostCategory>(entity =>
            {
                entity.HasOne(d => d.CostCategoryVersion)
                    .WithMany(p => p.VipLoungeCostCategories)
                    .HasForeignKey(d => d.CostCategoryVersionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.VipLounge)
                    .WithMany(p => p.VipLoungeCostCategories)
                    .HasForeignKey(d => d.VipLoungeID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
