using ATSimEntity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimData.Users
{
    public interface IUsersData
    {
        UsersEntity GetUsersEntity(string loginName);
        UsersEntity GetUsersEntity(long userId);
        IEnumerable<UsersEntity> GetUsers(ref int pageCount, int pageIndex = 0, int pageSize = 20);
    }
}
