using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBSample.Entities;

namespace MongoDBSample.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);

        IEnumerable<User> Get();
        User GetById(string id);

        User GetByName(string name);

        void Update(User user);

        void Delete(User user);
    }
}
