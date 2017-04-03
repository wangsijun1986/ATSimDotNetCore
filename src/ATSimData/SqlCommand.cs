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

namespace ATSimData
{
    public class SqlCommand:ISqlCommand
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
            if(!currentDirectory.Contains("src")){
                currentDirectory = string.Concat(currentDirectory,@"\src\ATSimWeb");
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

        public object ExecuteScalar(string sqlTextOrScriptName,DynamicParameters parameters, CommandType type, MySqlTransaction transaction = null)
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
    }
}
