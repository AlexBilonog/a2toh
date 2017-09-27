using Microsoft.EntityFrameworkCore;

namespace FRS.DataModel.Contracts.Infrastructure
{
    public interface IEntityEx
    {
        void ConfigureEx(ModelBuilder modelBuilder);
    }
}
