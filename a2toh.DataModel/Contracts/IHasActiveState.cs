
namespace FRS.Common.Contracts
{
    public interface IHasActiveState:IEntity
    {
        bool IsActive { get; set; }
    }
}
