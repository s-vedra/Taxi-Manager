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
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Choose role: ");
                    return (Role)HelperMethods.ReturnEnum(EntitiesDB.roles);
                }
                catch (ExceptionService msg)
                {
                    Console.WriteLine(msg.Error);
                }
            }
           
        }
        public void AddNewUser(ReturnPassword returnPassword, ReturnUsername returnUsername)
        {
            while (true)
            {
                try
                {
                    string? username = returnUsername();
                    string? password = returnPassword();

                    Role role = ReturnRole();
                    int id = HelperMethods.ReturnId(EntitiesDB.users);

                    User newUser = new User(id, username, password, role);
                    DBServices<User>.Add(EntitiesDB.users, newUser);
                    Console.WriteLine($"Successful creation of {newUser.Role} user!", HelperMethods.ChangeColor(ConsoleColor.Green));
                    break;
                }
                catch (ExceptionService msg)
                {
                    Console.WriteLine(msg.Error);
                    continue;
                }
            }

        }

        public User Login()
        {
            while (true)
            {
                try
                {
                    User user = DBServices<User>.ReturnUser();
                    Console.Clear();
                    Console.WriteLine($"Successful Login! Welcome {user.Role} {user.Username}", HelperMethods.ChangeColor(ConsoleColor.Green));
                    Console.ResetColor();
                    return user;
                }
                catch (ExceptionService msg)
                {
                    Console.WriteLine($"{msg.Error}", HelperMethods.ChangeColor(ConsoleColor.Red));
                    Console.ResetColor();
                    continue;
                }
            }

        }

        public void RemoveUser(int id)
        {
            PrintUsers(EntitiesDB.users);
            while (true)
            {
                try
                {
                    User user = DBServices<User>.ReturnEntityById(EntitiesDB.users);
                    if (user.Id == id)
                    {
                        Console.WriteLine("You can't do that");
                        continue;
                    }
                    else
                    {
                        DBServices<User>.Remove(EntitiesDB.users, user);
                        Console.WriteLine($"{user.Username} successfully removed", HelperMethods.ChangeColor(ConsoleColor.Green));
                        PrintUsers(EntitiesDB.users);
                    }
                    break;
                }
                catch (ExceptionService msg)
                {
                    Console.WriteLine(msg.Error);
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