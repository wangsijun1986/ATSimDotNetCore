using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSimEntity.AdminUser;
using Dapper;
using System.Data;

namespace ATSimData.AdminUser
{
    public class AdminUserData : IAdminUserData
    {
        protected readonly ISqlCommand command;

        public AdminUserData(ISqlCommand command)
        {
            this.command = command;
        }

        public void AddAdminUserInfo(AdminUserEntity entity)
        {
            string sql = @"INSERT INTO AdminUsers(LoginName,Phone,UserName,Password,Role,GroupId,OrganizationId,Email,UniqueCode)
                           VALUES(?LoginName,?Phone,?UserName,?Password,?Role,?GroupId,?OrganizationId,?Email,?UniqueCode)";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("?LoginName", entity.LoginName, DbType.AnsiString, size: 20);
            parameter.Add("?Phone", entity.Phone, DbType.AnsiString, size: 15);
            parameter.Add("?UserName", entity.UserName, DbType.AnsiString, size: 20);
            parameter.Add("?Password", entity.Password, DbType.AnsiString, size: 255);
            parameter.Add("?Role", entity.Role, DbType.AnsiString, size: 50);
            parameter.Add("?GroupId", entity.GroupId, DbType.Int32);
            parameter.Add("?OrganizationId", entity.OrganizationId, DbType.Int32);
            parameter.Add("?Email", entity.Email, DbType.AnsiString, size: 50);
            parameter.Add("?UniqueCode", entity.Password, DbType.AnsiString, size: 36);
            command.Execute(sql, parameter, CommandType.Text);
        }

        public bool CheckAdminUserExists(string loginName)
        {
            string sql = @"SELECT AdminId FROM AdminUsers WHERE LoginName=?LoginName Limit 1";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("?LoginName", loginName, DbType.AnsiString, size: 20);
            var obj = command.ExecuteScalar(sql, parameter, CommandType.Text);
            return obj != null;
        }

        public AdminUserEntity GetUserInfo(string loginName)
        {
            string sql = @"SELECT AdminId,LoginName,Phone,UserName,Password,Role,GroupId,OrganizationId,Email,CreateTime,LastLoginTime,CurrentlyLoginTime FROM AdminUsers WHERE LoginName=?LoginName";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("?LoginName", loginName, DbType.AnsiString, size: 20);
            return command.QueryEntity<AdminUserEntity>(sql, parameter, CommandType.Text);
        }

        public AdminUserEntity GetUserInfo(long id)
        {
            string sql = @"SELECT AdminId,LoginName,Phone,UserName,Password,Role,GroupId,OrganizationId,Email,CreateTime,LastLoginTime,CurrentlyLoginTime FROM AdminUsers WHERE AdminId=?AdminId";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("?AdminId", id, DbType.Int64, size: 11);
            return command.QueryEntity<AdminUserEntity>(sql, parameter, CommandType.Text);
        }
    }
}
