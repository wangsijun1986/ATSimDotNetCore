using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimCommon
{
    public static class RedisCommand
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return ConnectionMultiplexer.Connect(JObject.Parse(File.ReadAllText(string.Concat(currentDirectory, "/appsettings.json")))["RedisConnectionString"].ToString());
        });

        public static ConnectionMultiplexer Connection {
            get
            {
                return lazyConnection.Value;
            }
        }
        

    }
}
