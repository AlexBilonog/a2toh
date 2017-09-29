using FRS.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FRS.DataModel.Entities
{
    public class Product : AuditInfo, IEntity, IHasId
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public bool Discontinued { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitPrice { get; set; }

        public void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
            });
        }
    }
}
