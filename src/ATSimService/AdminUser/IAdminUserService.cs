using ATSimDto.AdminUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimService.AdminUser
{
    public interface IAdminUserService
    {
        AdminUserDto GetUserInfo(string loginName, string password);

        AdminUserDto GetUserInfo(long id);

        void AddAdminUserInfo(AdminUserRequestDto dto);
    }
}
