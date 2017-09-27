using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace FRS.DataModel.Entities
{
    public partial class EventWorkflowStep : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public DateTime? ExecutedDateTime { get; set; }
        public int? ExecutedUserId { get; set; }
        public DateTime? ExecutionDateDeadline { get; set; }
        public bool IsActualPhase { get; set; }
        public bool? IsBookingSuggestionActualPhase { get; set; }
        public bool? IsCurrent { get; set; }
        public int WorkflowStepId { get; set; }
        public int OrderNumber { get; set; }

        public ICollection<EventWorkflowStepHistory> EventWorkflowStepHistories { get; set; } = new HashSet<EventWorkflowStepHistory>();
        public Event Event { get; set; }
        public User User { get; set; }
        public WorkflowStep WorkflowStep { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventWorkflowStep>(entity =>
            {
                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventWorkflowSteps)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventWorkflowSteps)
                    .HasForeignKey(d => d.ExecutedUserId);

                entity.HasOne(d => d.WorkflowStep)
                    .WithMany(p => p.EventWorkflowSteps)
                    .HasForeignKey(d => d.WorkflowStepId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
