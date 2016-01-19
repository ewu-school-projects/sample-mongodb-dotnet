using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDBSample.Entities;

namespace MongoDBSample.DataLayer
{
    public interface IContext
    {
        IMongoCollection<User> AppUsers();
    }
}
