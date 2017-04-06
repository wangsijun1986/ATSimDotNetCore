using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSimDto.AdminUser;
using ATSimData.AdminUser;
using ATSimEntity.AdminUser;
using AutoMapper;
using ATSimCommon;
using StackExchange.Redis;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace ATSimService.AdminUser
{
    public class AdminUserService : IAdminUserService
    {
        protected readonly IAdminUserData adminUserData;
        protected readonly IDatabase db;
        public AdminUserService(IAdminUserData adminUserData)
        {
            db = RedisCommand.Connection.GetDatabase();
            this.adminUserData = adminUserData;
        }

        public void AddAdminUserInfo(AdminUserRequestDto dto)
        {
            if (adminUserData.CheckAdminUserExists(dto.LoginName))
            {
                throw new ArgumentException("AdminUserAlreadyExists");
            }
            var entity = Mapper.Map<AdminUserRequestDto, AdminUserEntity>(dto);
            entity.Password = new Encryption().EncryptValue(entity.Password);
            adminUserData.AddAdminUserInfo(entity);
        }

        public AdminUserDto GetUserInfo(string loginName, string password)
        {
            AdminUserEntity entity = adminUserData.GetUserInfo(loginName);
            string decryptPassword = new Encryption().DecryptValue(entity.Password);
            if (!password.Equals(decryptPassword))
            {
                throw new ArgumentException("PasswordNotEqual");
            }
            entity.Password = string.Empty;
            return Mapper.Map<AdminUserEntity, AdminUserDto>(entity);
        }
        /// <summary>
        /// 访问redis缓存示例代码
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AdminUserDto GetUserInfo(long id)
        {
            string key = string.Format("GetUserInfo@Id:{0}", id);
            AdminUserEntity entity = null;
            if (db.IsConnected(key) && db.KeyExists(key) && db.KeyType(key).Equals(RedisType.String))
            {
                string result = db.StringGet(key);
                entity = JObject.Parse(result).ToObject<AdminUserEntity>();
            }
            else
            {
                entity = adminUserData.GetUserInfo(id);
                if (entity == null)
                {
                    throw new ArgumentException("AdminUserNotExists");
                }
                if (db.IsConnected(key) && (!db.KeyExists(key) || db.KeyType(key).Equals(RedisType.String)))
                {
                    db.KeyDelete(key);
                    db.StringSet(key, JObject.FromObject(entity).ToString());
                }
            }
            return Mapper.Map<AdminUserEntity, AdminUserDto>(entity);
        }
    }
}
