
namespace FRS.Common.Contracts
{
    public interface IHasIsActive : IEntity
    {
        bool IsActive { get; set; }
    }
}
