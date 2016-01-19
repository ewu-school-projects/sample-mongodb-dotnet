using MongoDBSample.DataLayer;
using MongoDBSample.Repositories;
using MongoDBSample.Services;

namespace MongoDBSample.Utilities
{
    /// <summary>
    /// Best practice is to use a dependency injection library,
    /// but it is just easier to do this for the sake of this sample
    /// </summary>
    public static class Instantiator
    {
        public static IUserService NewUserService(string databasePassword)
        {
            return new UserService(NewUserRepository(databasePassword));
        }

        public static IUserRepository NewUserRepository(string databasePassword)
        {
            return new UserRepository(NewContext(databasePassword));
        }

        public static IContext NewContext(string databasePassword)
        {
            return new SampleContext(databasePassword);
        }
    }
}
