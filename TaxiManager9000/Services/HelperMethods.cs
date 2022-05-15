using System.Text.RegularExpressions;
using Enums;
using Models;
namespace Services
{
    public static class HelperMethods
    {


        public static int ReturnEnum<T>(List<T> enums)
        {
            while (true)
            {
                try
                {
                    for (int i = 0; i < enums.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} {enums[i]}");
                    }
                    int answer = Console.ReadLine().Parsing();
                    if (answer == 0 || answer > enums.Count)
                    {
                        throw new ExceptionService("User entered invalid message type");
                    }
                    return answer;
                }
                catch (ExceptionService)
                {
                    Console.WriteLine("Bad request, try again");
                    continue;
                }
            }
        }

        //method used to increment the ID number when adding a new user
        public static int ReturnId<T>(List<T> entities) where T : BaseEntity
        {
            int count = entities.Count + 1;

            foreach (T entity in entities)
            {
                if (entity.Id == count)
                {
                    count++;
                }
            }
            return count;
        }

        //method to change the text color in the console
        public static ConsoleColor ChangeColor(ConsoleColor color)
        {
            return Console.ForegroundColor = color;
        }

        //method to count the number of chars in the username when the new user is added
        public static string CountCharUsername()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter username");
                    string? message = Console.ReadLine();
                    char[] characters = message.ToCharArray();
                    int count = 0;
                    foreach (char c in characters)
                    {
                        count++;
                    }
                    if (count < 5)
                    {
                        return message;
                    }
                    throw new ExceptionService("User entered invalid message type for username");
                }
                catch (ExceptionService)
                {
                    Console.WriteLine("Username must contain atleats 5 characters");
                    continue;
                }
               
            }
           
        }

        //method to check the passoword when the new user is added, if the password is atleast 5 chars and has atleast one number
        public static string CountCharPassword()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter password");
                    string? message = Console.ReadLine();
                    Regex hasNumber = new Regex(@"[0-9]+");
                    char[] characters = message.ToCharArray();
                    int count = 0;
                    foreach (char c in characters)
                    {
                        count++;
                    }
                    if (!hasNumber.IsMatch(message) || count < 5)
                    {
                        throw new ExceptionService("User entered invalid message type for password");
                    }
                    return message;
                }
                catch (ExceptionService)
                {
                    Console.WriteLine("Password must contain atleats 5 characters and a number");
                    continue;
                }
               
            }
            

        }
        public static int Parsing(this string input)
        {
            while (true)
            {
                try
                {
                    if (!int.TryParse(input, out int num))
                    {
                        throw new ExceptionService("User entered invalid message type");
                    }
                    else
                    {
                        return num;
                    }
                }
                catch (ExceptionService)
                {
                    Console.WriteLine("Bad request, try again");
                    return 0;
                }
            }
        }

        public static void MainMenu()
        {
            Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
            Console.ReadLine();
            Console.Clear();
        }
    }

}
