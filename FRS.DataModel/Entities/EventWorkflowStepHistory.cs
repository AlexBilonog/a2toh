using FRS.Common.Contracts;
using FRS.DataModel.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace FRS.DataModel.Entities
{
    public partial class EventWorkflowStepHistory : IEntity, IHasUser
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int EventWorkflowStepId { get; set; }
        public DateTime FinishedDate { get; set; }
        public int FinishedUserId { get; set; }
        public int? RepresenterUserId { get; set; }
        public DateTime? WorkflowStepDeadline { get; set; }
        public int WorkflowStepTypeActionId { get; set; }

        public EventWorkflowStep EventWorkflowStep { get; set; }
        public User User { get; set; }
        public User User1 { get; set; }
        public WorkflowStepTypeAction WorkflowStepTypeAction { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventWorkflowStepHistory>(entity =>
            {
                entity.Property(e => e.Comment).HasMaxLength(500);

                entity.HasOne(d => d.EventWorkflowStep)
                    .WithMany(p => p.EventWorkflowStepHistories)
                    .HasForeignKey(d => d.EventWorkflowStepId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventWorkflowStepHistories)
                    .HasForeignKey(d => d.FinishedUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User1)
                    .WithMany(p => p.EventWorkflowStepHistories1)
                    .HasForeignKey(d => d.RepresenterUserId);

                entity.HasOne(d => d.WorkflowStepTypeAction)
                    .WithMany(p => p.EventWorkflowStepHistories)
                    .HasForeignKey(d => d.WorkflowStepTypeActionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
