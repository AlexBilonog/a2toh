using AutoMapper;

namespace FRS.Common.Contracts
{
    public interface IHasCustomMapping
    {
        void ConfigureMapping(IMapperConfigurationExpression config);
    }
}
