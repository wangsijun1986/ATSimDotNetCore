using ATSimEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimData.AdminUser
{
    public interface IAdminUserData
    {
        AdminUserEntity GetUserInfo(string userName);

        AdminUserEntity GetUserInfo(long id);

        bool CheckAdminUserExists(string userName);

        void AddAdminUserInfo(AdminUserEntity entity);
    }
}
