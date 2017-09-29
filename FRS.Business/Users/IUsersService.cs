using Kendo.Mvc.UI;
using System.Collections.Generic;

namespace FRS.Business.Users
{
    public interface IUsersService
    {
        DataSourceResult GetUsers(DataSourceRequest request);
        IEnumerable<UserDto> CreateUsers(IEnumerable<UserDto> dtos);
        IEnumerable<UserDto> UpdateUsers(IEnumerable<UserDto> dtos);
        void DeleteUsers(IEnumerable<UserDto> dtos);
    }
}
