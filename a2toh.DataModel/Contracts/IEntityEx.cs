using Microsoft.EntityFrameworkCore;

namespace EventManager.DataModel.Contracts.Infrastructure
{
    public interface IEntityEx
    {
        void ConfigureEx(ModelBuilder modelBuilder);
    }
}
