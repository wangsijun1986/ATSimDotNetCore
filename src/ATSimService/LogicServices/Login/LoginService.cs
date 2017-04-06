using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSimDto.AdminUser;
using ATSimDto.Users;
using ATSimData.AdminUser;
using ATSimData.Users;
using ATSimService.Location;
using ATSimEntity.AdminUser;
using ATSimCommon;
using AutoMapper;
using ATSimEntity.Location;

namespace ATSimService.LogicServices.Login
{
    public class LoginService : ILoginService
    {
        private IAdminUserData adminUserData;
        private IUsersData usersData;
        private ILocationService locationService;
        public LoginService(IAdminUserData adminUserData, IUsersData usersData, ILocationService locationService) {
            this.adminUserData = adminUserData;
            this.usersData = usersData;
            this.locationService = locationService;
        }

        public AdminUserDto AdminUserLogin(string loginName, string password)
        {
            AdminUserEntity entity = adminUserData.GetUserInfo(loginName);
            string decryptPassword = new Encryption().DecryptValue(entity.Password);
            if (!password.Equals(decryptPassword))
            {
                throw new ArgumentException("PasswordNotEqual");
            }
            entity.Password = "";
            return Mapper.Map<AdminUserDto>(entity);
        }

        public void UpdateCoordinate(long carId,string carNumber, double[] coordinate)
        {
            LocationEntity location = new LocationEntity();
            location.CarId = carId;
            location.CarNumber = carNumber;
            location.Coordinate = coordinate;
            locationService.UpdateCarLocation(location);
        }

        public UsersDto UsersLogin(string loginName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
