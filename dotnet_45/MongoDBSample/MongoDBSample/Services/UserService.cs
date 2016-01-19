using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDBSample.Entities;
using MongoDBSample.Repositories;

namespace MongoDBSample.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public void AddUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (user.Name == null)
                throw new ArgumentNullException(nameof(user.Name));

            user.Id = ObjectId.GenerateNewId().ToString();
            
            _userRepo.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepo.Get();
        } 

        public User GetUserByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return _userRepo.GetByName(name);
        }

        public void UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (user.Id == null)
                throw new ArgumentNullException(nameof(user.Id));
            if (user.Name == null)
                throw new ArgumentNullException(nameof(user.Name));
            if (_userRepo.GetById(user.Id) == null)
                throw new ArgumentException(nameof(user));

            _userRepo.Update(user);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (user.Id == null)
                throw new ArgumentNullException(nameof(user.Id));
            if (_userRepo.GetById(user.Id) == null)
                throw new ArgumentException(nameof(user));

            _userRepo.Delete(user);
        }
    }
}
