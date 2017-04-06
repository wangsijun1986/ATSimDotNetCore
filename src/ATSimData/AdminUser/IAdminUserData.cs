using ATSimEntity.AdminUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimData.AdminUser
{
    public interface IAdminUserData
    {
        AdminUserEntity GetUserInfo(string loginName);

        AdminUserEntity GetUserInfo(long id);

        bool CheckAdminUserExists(string loginName);

        void AddAdminUserInfo(AdminUserEntity entity);
    }
}
