using Microsoft.EntityFrameworkCore;

namespace FRS.Common.Contracts
{
    public interface IEntity
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
