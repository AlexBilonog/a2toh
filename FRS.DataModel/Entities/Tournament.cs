using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FRS.DataModel.Entities
{
    public partial class Tournament : IEntity, IHasId
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired();
            });
        }
    }
}
