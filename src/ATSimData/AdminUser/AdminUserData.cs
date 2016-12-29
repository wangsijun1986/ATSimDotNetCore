using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSimEntity;
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
            string sql = @"INSERT INTO AdminUser(UserName,Password,Role,Email)
                           VALUES(?UserName,?Password,?Role,?Email)";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("?UserName", entity.UserName, DbType.AnsiString, size: 50);
            parameter.Add("?Password", entity.Password, DbType.AnsiString, size: 255);
            parameter.Add("?Role", entity.Role, DbType.AnsiString, size: 50);
            parameter.Add("?Email", entity.Email, DbType.AnsiString, size: 50);
            command.Execute(sql, parameter, CommandType.Text);
        }

        public bool CheckAdminUserExists(string userName)
        {
            string sql = @"SELECT Id FROM AdminUser WHERE UserName=?UserName Limit 1";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("?UserName", userName, DbType.AnsiString, size: 50);
            var obj = command.ExecuteScalar(sql, parameter, CommandType.Text);
            return obj != null;
        }

        public AdminUserEntity GetUserInfo(string userName)
        {
            string sql = @"SELECT Id,UserName,Password,Role,Email,CreateTime,IsStop FROM AdminUser WHERE UserName=?UserName";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("?UserName", userName, DbType.AnsiString, size: 50);
            return command.QueryEntity<AdminUserEntity>(sql, parameter, CommandType.Text);
        }

        public AdminUserEntity GetUserInfo(long id)
        {
            string sql = @"SELECT Id,UserName,Role,Email,CreateTime,IsStop FROM AdminUser WHERE Id=?Id";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("?Id", id, DbType.Int64, size: 11);
            return command.QueryEntity<AdminUserEntity>(sql, parameter, CommandType.Text);
        }
    }
}
