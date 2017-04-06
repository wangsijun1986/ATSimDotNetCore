using ATSimDto.AdminUser;
using ATSimDto.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimService.LogicServices.Login
{
    public interface ILoginService
    {
        AdminUserDto AdminUserLogin(string loginName, string password);

        UsersDto UsersLogin(string loginName, string password);

        void UpdateCoordinate(long carId, string carNumber, double[] coordinate);

    }
}
