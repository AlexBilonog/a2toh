using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class VipLoungeCostQuestion : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public int CostQuestionVersionId { get; set; }
        public bool IsYes { get; set; }
        public int OrderNumber { get; set; }
        public int VipLoungeId { get; set; }

        public CostQuestionVersion CostQuestionVersion { get; set; }
        public VipLounge VipLounge { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VipLoungeCostQuestion>(entity =>
            {
                entity.HasOne(d => d.CostQuestionVersion)
                    .WithMany(p => p.VipLoungeCostQuestions)
                    .HasForeignKey(d => d.CostQuestionVersionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.VipLounge)
                    .WithMany(p => p.VipLoungeCostQuestions)
                    .HasForeignKey(d => d.VipLoungeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
