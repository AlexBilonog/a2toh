using FRS.Common.Contracts;
using FRS.DataModel.Entities;

namespace FRS.DataModel.Contracts
{
    public interface IHasUser: IEntity
    {
        User User { get; set; }
    }
}
