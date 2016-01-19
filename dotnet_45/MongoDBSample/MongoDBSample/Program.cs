using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBSample.Entities;
using MongoDBSample.Services;
using MongoDBSample.Utilities;

namespace MongoDBSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var p = new Program();
            p.Run();
        }

        public void Run()
        {
            Console.WriteLine("Welcome to a MongoDB Sample program.");
            var userService = GetNewUserService();
            while (true)
            {
                var opt = Menu();
                switch (opt)
                {
                    case 1:
                        var users = userService.GetAllUsers();

                        foreach (var user in users)
                        {
                            Console.WriteLine(user.ToString());
                        }

                        break;
                    case 2:
                        Console.Write("Please enter a name to lookup |> ");
                        var name = Console.ReadLine();
                        var queriedUser = userService.GetUserByName(name);
                        if (queriedUser == null)
                        {
                            Console.WriteLine("Could not find user by that name");
                            break;
                        }
                        Console.WriteLine(queriedUser.ToString());
                        break;
                    case 3:
                        Console.Write("Please enter a name |> ");
                        var newName = Console.ReadLine();
                        Console.Write("Please enter a value for the mutable field |> ");
                        var newMutableValue = Console.ReadLine();

                        if (userService.GetUserByName(newName) != null)
                        {
                            Console.WriteLine("A user by this name already exists!");
                            break;
                        }
                        var newUser = new User
                        {
                            Name = newName,
                            MutableField = newMutableValue
                        };
                        userService.AddUser(newUser);
                        break;
                    case 4:
                        Console.Write("Please enter the name of the user to update |> ");
                        name = Console.ReadLine();
                        if (name == "Will" || name == "Tim" || name == "Tari" || name == "Richard")
                        {
                            Console.WriteLine("These users cannot be deleted");
                            break;
                        }
                        var userToUpdate = userService.GetUserByName(name);
                        if (userToUpdate == null)
                        {
                            Console.WriteLine("Could not find user by that name");
                            break;
                        }
                        Console.WriteLine("Please enter a new mutable value |> ");
                        userToUpdate.MutableField = Console.ReadLine();
                        userService.UpdateUser(userToUpdate);
                        break;
                    case 5:
                        Console.Write("Please enter the name of the user to delete |> ");
                        name = Console.ReadLine();
                        if (name == "Will" || name == "Tim" || name == "Tari" || name == "Richard")
                        {
                            Console.WriteLine("These users cannot be deleted");
                            break;
                        }
                        var userToDelete = userService.GetUserByName(name);
                        if (userToDelete == null)
                        {
                            Console.WriteLine("Could not find user by that name");
                            break;
                        }
                        userService.DeleteUser(userToDelete);
                        break;
                    case 6:
                        Console.WriteLine("Goodbye!");
                        return;
                }
            }
        }

        public IUserService GetNewUserService()
        {
            Console.WriteLine("Please enter the password to connect to the database");
            while (true)
            {
                Console.Write("|> ");
                try
                {
                    var pass = Console.ReadLine();
                    Console.WriteLine("Attempting to connect...");
                    var userService = Instantiator.NewUserService(pass);
                    Console.WriteLine("Connected to MongoDB");
                    return userService;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Password!");
                }
            }
        }

        public int Menu()
        {
            Console.WriteLine("Please choose from the following: ");
            Console.WriteLine("1. View all users");
            Console.WriteLine("2. Query for a user");
            Console.WriteLine("3. Add new user");
            Console.WriteLine("4. Update user");
            Console.WriteLine("5. Delete user");
            Console.WriteLine("6. Exit");
            while (true)
            {
                Console.Write("|> ");

                var option = Convert.ToInt32(Console.ReadLine());
                

                if (option >= 1 || option <= 6)
                    return option;
                Console.WriteLine("Not a valid option. Please try again.");
            }
        }
    }
}
