using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDBSample.DataLayer;
using MongoDBSample.Entities;

namespace MongoDBSample.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IContext _db;

        public UserRepository(IContext context)
        {
            _db = context;
        }
        public void Add(User user)
        {
            _db.AppUsers()
               .InsertOne(user);
        }

        public IEnumerable<User> Get()
        {
            return _db.AppUsers()
                .Find(x => true)
                .ToList();
        } 

        public User GetById(string id)
        {
            return _db.AppUsers()
                .Find(x => x.Id == id)
                .ToList()
                .FirstOrDefault();
        }

        public User GetByName(string name)
        {
            return _db.AppUsers()
                .Find(x => x.Name == name)
                .ToList()
                .FirstOrDefault();
        }

        public void Update(User user)
        {
            _db.AppUsers()
               .FindOneAndReplace(x => x.Id == user.Id, user);
        }

        public void Delete(User user)
        {
            _db.AppUsers()
               .DeleteOne(x => x.Id == user.Id);
        }
    }
}
