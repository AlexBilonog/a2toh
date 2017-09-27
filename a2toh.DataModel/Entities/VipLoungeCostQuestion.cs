using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManager.DataModel.Entities
{
    public partial class VipLoungeCostQuestion : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public int CostQuestionVersionID { get; set; }
        public bool IsYes { get; set; }
        public int OrderNumber { get; set; }
        public int VipLoungeID { get; set; }

        public CostQuestionVersion CostQuestionVersion { get; set; }
        public VipLounge VipLounge { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungeCostQuestion>(entity =>
            {
                entity.HasOne(d => d.CostQuestionVersion)
                    .WithMany(p => p.VipLoungeCostQuestions)
                    .HasForeignKey(d => d.CostQuestionVersionID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.VipLounge)
                    .WithMany(p => p.VipLoungeCostQuestions)
                    .HasForeignKey(d => d.VipLoungeID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
