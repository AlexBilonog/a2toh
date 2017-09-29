using FRS.Business.Users;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FRS.Web.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public DataSourceResult GetUsers([DataSourceRequest]DataSourceRequest request)
        {
            return _usersService.GetUsers(request);
        }

        [HttpPost]
        public IEnumerable<UserDto> CreateUsers([FromBody]IEnumerable<UserDto> dtos)
        {
            return _usersService.CreateUsers(dtos);
        }

        [HttpPut]
        public IEnumerable<UserDto> UpdateUsers([FromBody]IEnumerable<UserDto> dtos)
        {
            return _usersService.UpdateUsers(dtos);
        }

        [HttpDelete]
        public void DeleteUsers([FromBody]IEnumerable<UserDto> dtos)
        {
            _usersService.DeleteUsers(dtos);
        }
    }
}
