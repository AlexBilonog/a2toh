using EventManager.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EventManager.DataModel.Entities
{
    public partial class DataConditionCriteria : AuditInfo, IEntity, IHasId
    {
        public int ID { get; set; }
        public string BasicFieldCode { get; set; }
        public int? BasicFieldEventTypeID { get; set; }
        public int ConditionCriteriaOperatorID { get; set; }
        public int ConditionOperatorID { get; set; }
        public int DataConditionFieldID { get; set; }
        public int DataRoleID { get; set; }
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
                    .HasForeignKey(d => d.BasicFieldEventTypeID);

                entity.HasOne(d => d.ConditionCriteriaOperator)
                    .WithMany(p => p.DataConditionCriterias)
                    .HasForeignKey(d => d.ConditionCriteriaOperatorID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ConditionOperator)
                    .WithMany(p => p.DataConditionCriterias)
                    .HasForeignKey(d => d.ConditionOperatorID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.DataConditionField)
                    .WithMany(p => p.DataConditionCriterias)
                    .HasForeignKey(d => d.DataConditionFieldID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.DataRole)
                    .WithMany(p => p.DataConditionCriterias)
                    .HasForeignKey(d => d.DataRoleID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
