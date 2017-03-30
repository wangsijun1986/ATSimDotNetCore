using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ATSimEntity;
using System.Data;
using System.Runtime.CompilerServices;

namespace ATSimData
{
    public class HelloWordData : IHelloWordData
    {
        private readonly ISqlCommand command;
        public HelloWordData(ISqlCommand sqlCommand)
        {
            command = sqlCommand;
        }
        public string GetData(UserEntity user)
        {
            //These code is used to test global exception attribute.
            DynamicParameters paramtere = new DynamicParameters();
            paramtere.Add("?username", user.UserName, DbType.AnsiString);
            paramtere.Add("?url", user.Url, DbType.AnsiString);
            paramtere.Add("?age", user.Age, DbType.Int32);
            int result = command.Execute("insert into test.user(id,username,url,age)values(?id,?username,?url,?age)",paramtere,CommandType.Text);


            //Task<UserEntity> task = command.QueryEntityAsync<UserEntity>("select * from user", CommandType.Text);
            //TaskAwaiter<UserEntity> awaiter = task.GetAwaiter();
            //if (awaiter.IsCompleted)
            //{
            //    Console.WriteLine("Starting wait");
            //    Console.WriteLine(DateTime.Now.ToFileTime().ToString());
            //    task.Wait();
            //    Console.WriteLine("End Wait");
            //    Console.WriteLine(DateTime.Now.ToFileTime().ToString());
            //}
            //Console.WriteLine("goto here");
            //Console.WriteLine(DateTime.Now.ToFileTime().ToString());
            //UserEntity entity = awaiter.GetResult()?? new UserEntity();
            //throw new ArgumentException("test argumentException");
            return result.ToString();
        }
    }
}
