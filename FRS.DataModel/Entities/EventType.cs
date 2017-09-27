using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class EventType : AuditInfo, IEntity, IHasActiveState, IHasId
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public int OrderNumber { get; set; }

        public ICollection<BookingSuggestionAccountMapping> BookingSuggestionAccountMappings { get; set; } = new HashSet<BookingSuggestionAccountMapping>();
        public ICollection<DataConditionCriteria> DataConditionCriterias { get; set; } = new HashSet<DataConditionCriteria>();
        public ICollection<EmailTemplate> EmailTemplates { get; set; } = new HashSet<EmailTemplate>();
        public ICollection<EventTypeVersion> EventTypeVersions { get; set; } = new HashSet<EventTypeVersion>();
        public ICollection<EventTypeWorkflowStep> EventTypeWorkflowSteps { get; set; } = new HashSet<EventTypeWorkflowStep>();
        public ICollection<VipLounge> VipLounges { get; set; } = new HashSet<VipLounge>();
        public ICollection<WageTypeMapping> WageTypeMappings { get; set; } = new HashSet<WageTypeMapping>();

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventType>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(100);
            });
        }
    }
}
