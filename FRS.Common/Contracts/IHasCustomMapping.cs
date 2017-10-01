using AutoMapper;

namespace FRS.Common.Contracts
{
    public interface IHasCustomMapping
    {
        void ConfigureMapping(IProfileExpression config);
    }
}
