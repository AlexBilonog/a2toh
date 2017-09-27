using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FRS.DataModel.Entities
{
    public partial class DataConditionCriteria : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public string BasicFieldCode { get; set; }
        public int? BasicFieldEventTypeId { get; set; }
        public int ConditionCriteriaOperatorId { get; set; }
        public int ConditionOperatorId { get; set; }
        public int DataConditionFieldId { get; set; }
        public int DataRoleId { get; set; }
        public int OrderNumber { get; set; }
        public string Value { get; set; }

        public EventType EventType { get; set; }
        public ConditionCriteriaOperator ConditionCriteriaOperator { get; set; }
        public ConditionOperator ConditionOperator { get; set; }
        public DataConditionField DataConditionField { get; set; }
        public DataRole DataRole { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataConditionCriteria>(entity =>
            {
                entity.Property(e => e.BasicFieldCode).HasMaxLength(10);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.DataConditionCriterias)
                    .HasForeignKey(d => d.BasicFieldEventTypeId);

                entity.HasOne(d => d.ConditionCriteriaOperator)
                    .WithMany(p => p.DataConditionCriterias)
                    .HasForeignKey(d => d.ConditionCriteriaOperatorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ConditionOperator)
                    .WithMany(p => p.DataConditionCriterias)
                    .HasForeignKey(d => d.ConditionOperatorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.DataConditionField)
                    .WithMany(p => p.DataConditionCriterias)
                    .HasForeignKey(d => d.DataConditionFieldId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.DataRole)
                    .WithMany(p => p.DataConditionCriterias)
                    .HasForeignKey(d => d.DataRoleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
