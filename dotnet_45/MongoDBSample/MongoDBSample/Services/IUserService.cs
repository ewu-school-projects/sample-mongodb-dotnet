using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBSample.Entities;

namespace MongoDBSample.Services
{
    public interface IUserService
    {
        void AddUser(User user);

        IEnumerable<User> GetAllUsers();
        User GetUserByName(string name);

        void UpdateUser(User user);

        void DeleteUser(User user);
    }
}
