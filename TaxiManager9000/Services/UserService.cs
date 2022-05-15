using Enums;
using Models;
using Services.Interfaces;

namespace Services
{
    public class UserService : IUserService
    {
        public delegate string ReturnUsername();
        public delegate string ReturnPassword();

        public static Role ReturnRole()
        {
            Console.Clear();
            Console.WriteLine("Choose role: ");
            return (Role)HelperMethods.ReturnEnum(EntitiesDB.roles);
        }
        public void AddNewUser(ReturnPassword returnPassword, ReturnUsername returnUsername)
        {
             
            string username = returnUsername();
            string? password = returnPassword();

            Role role = ReturnRole();
            int id = HelperMethods.ReturnId(EntitiesDB.users);
               
            User newUser = new User(id, username, password, role);
            DBServices<User>.Add(EntitiesDB.users, newUser);
            Console.WriteLine($"Successful creation of {newUser.Role} user!", HelperMethods.ChangeColor(ConsoleColor.Green));

        }

        public User Login()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter username", HelperMethods.ChangeColor(ConsoleColor.White));
                    string? username = Console.ReadLine();
                    Console.WriteLine("Enter password");
                    string? password = Console.ReadLine();
                    User? user = EntitiesDB.users.SingleOrDefault(user => user.Username == username && user.CheckPassword(password));
                    if (user == null)
                    {
                        throw new ExceptionService($"User entered wrong username or password. Entered message: username - {username}, password - {password}");
                    }
                    else
                    {
                        HelperMethods.ChangeColor(ConsoleColor.Green);
                        Console.WriteLine($"Successful Login! Welcome {user.Role} {user.Username}");
                        return user;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Login unsuccessful. Please try again", HelperMethods.ChangeColor(ConsoleColor.Red));
                    continue;
                }
            }

        }

        public void RemoveUser(int id)
        {
            while (true)
            {
                try
                {
                    PrintUsers(EntitiesDB.users);
                    User user = DBServices<User>.ReturnEntity(EntitiesDB.users);
                    if (user.Id == id)
                    {
                        throw new ExceptionService("User entered invalid Id");
                    }
                    else
                    {
                        DBServices<User>.Remove(EntitiesDB.users, user);
                        Console.WriteLine($"{user.Username} successfully removed", HelperMethods.ChangeColor(ConsoleColor.Green));
                        PrintUsers(EntitiesDB.users);
                    }
                    break;
                }
                catch (ExceptionService)
                {
                    Console.WriteLine("You can't do that!");
                    continue;
                }
            }

        }

        public void ChangePassword(User user)
        {
            while (true)
            {
                Console.WriteLine("Enter new password:", HelperMethods.ChangeColor(ConsoleColor.White));
                if (user.ChangePassword(Console.ReadLine()))
                {
                    Console.WriteLine("Successfuly changed password!", HelperMethods.ChangeColor(ConsoleColor.Green));
                    break;
                }
                else
                {
                    Console.WriteLine("Password change unsuccessful. Please try again", HelperMethods.ChangeColor(ConsoleColor.Red));
                    continue;
                }
            }

        }

        public static void PrintUsers(List<User> users)
        {
            DBServices<User>.PrintEntities(users, (users) => users.ForEach(user => Console.WriteLine(user.PrintInfo(), HelperMethods.ChangeColor(ConsoleColor.White))));
        }
    }
}