using AutoMapper;

namespace FRS.Web.Contracts
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
