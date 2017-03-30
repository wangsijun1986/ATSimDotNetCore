using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ATSimData
{
    public class MongoDBCommand<T>
    {
        private static string mongoDbServer;
        private static string mongoDbName;

        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<T> collection;

        public MongoDBCommand(string collationName)
        {
            if (string.IsNullOrWhiteSpace(mongoDbServer)||string.IsNullOrWhiteSpace(mongoDbName))
            {
                string currentDirectory = getCurrentDirectory();
                JObject jobject = JObject.Parse(File.ReadAllText(string.Concat(currentDirectory, "/appsettings.json")));
                mongoDbServer = jobject["MongoDBConnectionString"].ToString();
                mongoDbName = jobject["MongoDBName"].ToString();
            }
            client = new MongoClient(mongoDbServer);
            database = client.GetDatabase(mongoDbName);
            collection = database.GetCollection<T>(collationName);
        }
        private string getCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }
        
        public async Task InsertAsync(T document)
        {
            await collection.InsertOneAsync(document);
        }

        public async Task InsertAsync(IEnumerable<T> documents)
        {
            await collection.InsertManyAsync(documents);
        }

        public async Task<T> SelectOneAsync(Expression<Func<T, bool>> func)
        {
            return await collection.Find<T>(func).FirstOrDefaultAsync();
        }

        public async Task<List<T>> SelectMore(Expression<Func<T, bool>> func)
        {
            FilterDefinitionBuilder<T> builder = new FilterDefinitionBuilder<T>();
            
            return await collection.Find(func).ToListAsync();
        }
        public IFindFluent<T,T> SelectMoreLocationNear(Expression<Func<T, object>> func, FilterDefinitionBuilder<T> builder,double x,double y)
        {
            return collection.Find(builder.Near(func, x, y));
        }
        public async Task<T> SelectOneAndUpdate(Expression<Func<T,bool>> func,UpdateDefinition<T> documents)
        {
            return await collection.FindOneAndUpdateAsync<T>(func, documents);
        }

        public async Task<T> SelectOneAndReplace(Expression<Func<T, bool>> func, T documents)
        {
            return await collection.FindOneAndReplaceAsync<T>(func, documents);
        }

        public DeleteResult SelectOneAndDelete(FilterDefinition<T> document, DeleteOptions collation) {
            return collection.DeleteOne(document, collation);
        }
    }
}
