using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDBSample.Entities;

namespace MongoDBSample.DataLayer
{
    public class SampleContext : IContext, IDisposable
    {
        private IMongoDatabase _db;

        public SampleContext(string databasePassword)
        {
            var connectionString = new AppSettingsReader().GetValue("sampleDb", typeof (string)).ToString();
            connectionString = connectionString.Replace("{{password}}", databasePassword);
            var client = new MongoClient(connectionString);
            _db = client.GetDatabase(connectionString.Split('/').Last());
        }

        public IMongoCollection<User> AppUsers()
        {
            return _db.GetCollection<User>("User");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
