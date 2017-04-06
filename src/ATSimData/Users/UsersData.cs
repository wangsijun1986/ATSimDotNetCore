using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSimEntity.Users;
using Dapper;

namespace ATSimData.Users
{
    public class UsersData : IUsersData
    {
        protected readonly ISqlCommand command;
        public UsersData(ISqlCommand command)
        {
            this.command = command;
        }

        public IEnumerable<UsersEntity> GetUsers(ref int pageCount,int pageIndex = 0, int pageSize = 20)
        {
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@pageIndex", pageIndex, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@pageSize", pageSize, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@pagecount", pageCount, System.Data.DbType.Int32, System.Data.ParameterDirection.Output);
            var entities = command.FindToListByPage<UsersEntity>("USP_Page_Users", parameter);
            return entities;
        }

        public UsersEntity GetUsersEntity(long userId)
        {
            throw new NotImplementedException();
        }

        public UsersEntity GetUsersEntity(string loginName)
        {
            throw new NotImplementedException();
        }
    }
}
