using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FRS.DataModel.Entities
{
    public partial class Tournament : IEntity, IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired();
            });
        }
    }
}
