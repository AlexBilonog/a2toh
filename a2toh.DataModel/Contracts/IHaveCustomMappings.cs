using AutoMapper;

namespace EventManager.Web.Contracts
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
