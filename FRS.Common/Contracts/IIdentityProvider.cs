using System.Security.Principal;

namespace FRS.Common.Contracts
{
    public interface IIdentityProvider
    {
        IIdentity GetCurrentIdentity();
    }
}
