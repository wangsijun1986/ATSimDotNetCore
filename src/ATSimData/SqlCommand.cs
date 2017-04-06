using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Dapper;
using System.Data;
using System.Reflection;

namespace ATSimData
{
    public class SqlCommand : ISqlCommand
    {
        private static string connection;

        public SqlCommand()
        {
            if (string.IsNullOrWhiteSpace(connection))
            {
                connection = GetConnectionString();

            }
        }

        private string GetConnectionString()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            if (!currentDirectory.Contains("src"))
            {
                currentDirectory = string.Concat(currentDirectory, @"\src\ATSimWeb");
            }
            string connectionString = JObject.Parse(File.ReadAllText(string.Concat(currentDirectory, @"\appsettings.json")))["MySqlConnectionString"].ToString();
            return connectionString;
        }

        private void setEncoding()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        private void CheckSqlTextOrScriptName(string sqlTextOrScriptName)
        {
            if (string.IsNullOrWhiteSpace(sqlTextOrScriptName))
            {
                throw new ArgumentException("sqlTextOrScriptName can not be null or empty.");
            }
        }

        private void CheckParameters(DynamicParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentException("paramters can not be null.");
            }
        }

        public IEnumerable<T> Query<T>(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            CheckParameters(parameters);
            using (var conn = new MySqlConnection(connection))
            {
                return conn.Query<T>(sqlTextOrScriptName, parameters, transaction: transaction, commandType: type);
            }
        }

        public IEnumerable<T> Query<T>(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            using (var conn = new MySqlConnection(connection))
            {
                return conn.Query<T>(sqlTextOrScriptName, transaction: transaction, commandType: type);
            }
        }

        public T QueryEntity<T>(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            CheckParameters(parameters);
            using (var conn = new MySqlConnection(connection))
            {
                return conn.Query<T>(sqlTextOrScriptName, parameters, transaction: transaction, commandType: type).FirstOrDefault();
            }
        }
        public T QueryEntity<T>(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            using (var conn = new MySqlConnection(connection))
            {
                return conn.Query<T>(sqlTextOrScriptName, transaction: transaction, commandType: type).FirstOrDefault();
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            CheckParameters(parameters);
            using (var conn = new MySqlConnection(connection))
            {
                return await conn.QueryAsync<T>(sqlTextOrScriptName, parameters, transaction: transaction, commandType: type);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            using (var conn = new MySqlConnection(connection))
            {
                return await conn.QueryAsync<T>(sqlTextOrScriptName, transaction: transaction, commandType: type);
            }
        }

        public async Task<T> QueryEntityAsync<T>(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            CheckParameters(parameters);
            using (var conn = new MySqlConnection(connection))
            {
                var result = await conn.QueryAsync<T>(sqlTextOrScriptName, parameters, transaction: transaction, commandType: type);
                return result.FirstOrDefault();
            }
        }
        public async Task<T> QueryEntityAsync<T>(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            using (var conn = new MySqlConnection(connection))
            {
                var result = await conn.QueryAsync<T>(sqlTextOrScriptName, transaction: transaction, commandType: type);
                return result.FirstOrDefault();
            }
        }

        public int Execute(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            CheckParameters(parameters);
            using (var conn = new MySqlConnection(connection))
            {
                return conn.Execute(sqlTextOrScriptName, parameters, transaction: transaction, commandType: type);
            }
        }
        public int Execute(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            using (var conn = new MySqlConnection(connection))
            {
                return conn.Execute(sqlTextOrScriptName, transaction: transaction, commandType: type);
            }
        }
        public async Task<int> ExecuteAsync(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            CheckParameters(parameters);
            using (var conn = new MySqlConnection(connection))
            {
                return await conn.ExecuteAsync(sqlTextOrScriptName, parameters, transaction: transaction, commandType: type);

            }
        }
        public async Task<int> ExecuteAsync(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            using (var conn = new MySqlConnection(connection))
            {
                return await conn.ExecuteAsync(sqlTextOrScriptName, transaction: transaction, commandType: type);

            }
        }

        public object ExecuteScalar(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            CheckParameters(parameters);
            using (var conn = new MySqlConnection(connection))
            {
                return conn.ExecuteScalar(sqlTextOrScriptName, parameters, transaction: transaction, commandType: type);
            }
        }
        public object ExecuteScalar(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            using (var conn = new MySqlConnection(connection))
            {
                return conn.ExecuteScalar(sqlTextOrScriptName, transaction: transaction, commandType: type);
            }
        }
        public async Task<object> ExecuteScalarAsync(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            CheckParameters(parameters);
            using (var conn = new MySqlConnection(connection))
            {
                return await conn.ExecuteScalarAsync(sqlTextOrScriptName, parameters, transaction: transaction, commandType: type);
            }
        }
        public async Task<object> ExecuteScalarAsync(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            using (var conn = new MySqlConnection(connection))
            {
                return await conn.ExecuteScalarAsync(sqlTextOrScriptName, transaction: transaction, commandType: type);
            }
        }

        public object ExecuteReader(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            CheckParameters(parameters);
            using (var conn = new MySqlConnection(connection))
            {
                return conn.ExecuteReader(sqlTextOrScriptName, parameters, transaction: transaction, commandType: type);
            }
        }
        public object ExecuteReader(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            using (var conn = new MySqlConnection(connection))
            {
                return conn.ExecuteReader(sqlTextOrScriptName, transaction: transaction, commandType: type);
            }
        }

        public async Task<object> ExecuteReaderAsync(string sqlTextOrScriptName, DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            CheckParameters(parameters);
            using (var conn = new MySqlConnection(connection))
            {
                return await conn.ExecuteReaderAsync(sqlTextOrScriptName, parameters, transaction: transaction, commandType: type);
            }
        }
        public async Task<object> ExecuteReaderAsync(string sqlTextOrScriptName, CommandType type, MySqlTransaction transaction = null)
        {
            CheckSqlTextOrScriptName(sqlTextOrScriptName);
            using (var conn = new MySqlConnection(connection))
            {
                return await conn.ExecuteReaderAsync(sqlTextOrScriptName, transaction: transaction, commandType: type);
            }
        }

        #region 同步分页查询数据集合
        /// <summary>
        /// 同步分页查询数据集合
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="cmd">sql语句或存储过程名称</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public IList<T> FindToListByPage<T>(string cmd, DynamicParameters param, bool flag = true) where T : class, new()
        {
            CheckSqlTextOrScriptName(cmd);
            CheckParameters(param);
            IDataReader dataReader = null;
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                if (flag)
                {
                    dataReader = conn.ExecuteReader(cmd, param, null, null, CommandType.StoredProcedure);
                }
                else
                {
                    dataReader = conn.ExecuteReader(cmd, param, null, null, CommandType.Text);
                }
                if (dataReader == null || !dataReader.Read()) return null;
                Type type = typeof(T);
                List<T> tlist = new List<T>();
                while (dataReader.Read())
                {
                    T t = new T();
                    foreach (var item in type.GetProperties())
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                            var kvalue = dataReader[item.Name];
                            if (kvalue == DBNull.Value) continue;
                            item.SetValue(t, kvalue, null);
                            break;
                        }
                    }
                    if (tlist != null) tlist.Add(t);
                }
                return tlist;
            }
        }
        #endregion

        #region 分页查询集合
        /// <summary>
        /// 异步分页查询数据集合
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="cmd">sql语句或存储过程名称</param>
        /// <param name="param">参数</param>
        /// <param name="flag">true存储过程，false sql语句</param>
        /// <returns>t</returns>
        public async Task<IList<T>> FindToListByPageAsync<T>(string cmd, DynamicParameters param, bool flag = true) where T : class, new()
        {
            CheckSqlTextOrScriptName(cmd);
            CheckParameters(param);
            IDataReader dataReader = null;
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                if (flag)
                {
                    dataReader = await conn.ExecuteReaderAsync(cmd, param, null, null, CommandType.StoredProcedure);
                }
                else
                {
                    dataReader = await conn.ExecuteReaderAsync(cmd, param, null, null, CommandType.Text);
                }
                if (dataReader == null || !dataReader.Read()) return null;
                Type type = typeof(T);
                List<T> tlist = new List<T>();
                while (dataReader.Read())
                {
                    T t = new T();
                    foreach (var item in type.GetProperties())
                    {
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            if (item.Name.ToLower() != dataReader.GetName(i).ToLower()) continue;
                            var kvalue = dataReader[item.Name];
                            if (kvalue == DBNull.Value) continue;
                            item.SetValue(t, kvalue, null);
                            break;
                        }
                    }
                    if (tlist != null) tlist.Add(t);
                }
                return tlist;
            }
        }
        #endregion
    }
}
