using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimData
{
    public interface ISqlCommand
    {
        IEnumerable<T> Query<T>(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null);
        IEnumerable<T> Query<T>(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null);
        T QueryEntity<T>(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null);
        T QueryEntity<T>(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null);
        Task<T> QueryEntityAsync<T>(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null);
        Task<T> QueryEntityAsync<T>(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null);
        int Execute(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null);
        int Execute(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null);
        Task<int> ExecuteAsync(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null);
        Task<int> ExecuteAsync(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null);
        object ExecuteScalar(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null);
        object ExecuteScalar(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null);
        Task<object> ExecuteScalarAsync(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null);
        Task<object> ExecuteScalarAsync(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null);
        object ExecuteReader(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null);
        object ExecuteReader(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null);
        Task<object> ExecuteReaderAsync(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null);
        Task<object> ExecuteReaderAsync(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null);
        IList<T> FindToListByPage<T>(string cmd, DynamicParameters param, bool flag = true) where T : class, new();
        Task<IList<T>> FindToListByPageAsync<T>(string cmd, DynamicParameters param, bool flag = true) where T : class, new();
    }
}
