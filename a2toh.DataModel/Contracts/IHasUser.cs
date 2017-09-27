using EventManager.Common.Contracts;
using EventManager.DataModel.Entities;

namespace EventManager.DataModel.Contracts
{
    public interface IHasUser: IEntity
    {
        User User { get; set; }
    }
}
