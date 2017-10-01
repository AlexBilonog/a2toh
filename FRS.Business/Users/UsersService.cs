using FRS.Business.Common;
using FRS.DataModel.Entities;
using Kendo.Mvc.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace FRS.Business.Users
{
    public class UsersService : BaseService, IUsersService
    {
        public UsersService(DbContext context, ILogger<UsersService> logger, ICacheProvider cacheProvider)
            : base(context, logger, cacheProvider)
        {
        }

        public DataSourceResult GetUsers(DataSourceRequest request)
        {
            return GetEntitiesForGrid<User, UserDto>(request);
        }

        public IEnumerable<UserDto> CreateUsers(IEnumerable<UserDto> dtos)
        {
            return CreateEntitiesForGrid<User, UserDto>(dtos);
        }

        public IEnumerable<UserDto> UpdateUsers(IEnumerable<UserDto> dtos)
        {
            return UpdateEntitiesForGrid<User, UserDto>(dtos);
        }

        public void DeleteUsers(IEnumerable<UserDto> dtos)
        {
            DeleteEntitiesForGrid<User, UserDto>(dtos);
        }
    }
}
