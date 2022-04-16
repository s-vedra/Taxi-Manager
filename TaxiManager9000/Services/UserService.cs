using Enums;
using Models;
using Services.Interfaces;

namespace Services
{
    public class UserService : IUserService
    {
        public void AddNewUser()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter username");
                    string username = Console.ReadLine();
                    if (!HelperMethods.CountCharUsername(username))
                    {
                        throw new Exception("Username must contain atleats 5 characters");
                    }
                    else
                    {
                        Console.WriteLine("Enter password");
                        string password = Console.ReadLine();
                        if (HelperMethods.CountCharPassword(password))
                        {
                            Console.WriteLine("Choose role \n1.Admin \n2.Manager \n3.Maintenance");
                            int userRole = HelperMethods.Parsing(Console.ReadLine());
                            if (userRole > 3 || userRole == 0)
                            {
                                throw new Exception("Please choose 1-3");
                            }
                            else
                            {
                                Role role = (Role)userRole;
                                User newUser = new User(HelperMethods.ReturnId(EntitiesDB.users), username, password, role);
                                DBServices<User>.Add(EntitiesDB.users, newUser);
                                Console.WriteLine($"Successful creation of {newUser.Role} user!", HelperMethods.ChangeColor(ConsoleColor.Green));
                                break;
                            }
                        }
                        else
                        {
                            throw new Exception("Password must contain atleats 5 characters and a number");
                        }
                    }
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
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
                    Console.WriteLine("Enter username", HelperMethods.ChangeColor(ConsoleColor.White));
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter password");
                    string password = Console.ReadLine();
                    User user = EntitiesDB.users.SingleOrDefault(user => user.CheckUsername(username) && user.CheckPassword(password));
                    if (user == null)
                    {
                        throw new Exception("Login unsuccessful. Please try again");
                    }
                    else
                    {
                        HelperMethods.ChangeColor(ConsoleColor.Green);
                        Console.WriteLine($"Successful Login! Welcome {user.Role} {user.Username}");
                        return user;
                    }
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message, HelperMethods.ChangeColor(ConsoleColor.Red));
                    continue;
                }
            }

        }

        public User RemoveUser()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter id:");
                    int id = HelperMethods.Parsing(Console.ReadLine());
                    User user = EntitiesDB.users.SingleOrDefault(user => user.Id == id);
                    if (user == null)
                    {
                        throw new Exception("No user found, try again");
                    }
                    else
                    {

                        return user;
                    }
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
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
                    Console.WriteLine("Successful change password!", HelperMethods.ChangeColor(ConsoleColor.Green));
                    break;
                }
                else
                {
                    Console.WriteLine("Password change unsuccessful. Please try again", HelperMethods.ChangeColor(ConsoleColor.Red));
                    continue;
                }
            }

        }

        public void PrintUsers()
        {
            DBServices<User>.PrintEntities(EntitiesDB.users);
        }
    }
}