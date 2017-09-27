using EventManager.Common.Contracts;
using EventManager.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace EventManager.DataModel.Entities
{
    public partial class EventWorkflowStep : AuditInfo, IEntity, IHasUser, IHasId
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public DateTime? ExecutedDateTime { get; set; }
        public int? ExecutedUserID { get; set; }
        public DateTime? ExecutionDateDeadline { get; set; }
        public bool IsActualPhase { get; set; }
        public bool? IsBookingSuggestionActualPhase { get; set; }
        public bool? IsCurrent { get; set; }
        public int WorkflowStepID { get; set; }
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
                    .HasForeignKey(d => d.EventID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventWorkflowSteps)
                    .HasForeignKey(d => d.ExecutedUserID);

                entity.HasOne(d => d.WorkflowStep)
                    .WithMany(p => p.EventWorkflowSteps)
                    .HasForeignKey(d => d.WorkflowStepID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}