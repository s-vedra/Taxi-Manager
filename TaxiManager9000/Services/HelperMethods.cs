using Models;
using System.Text.RegularExpressions;
namespace Services
{
    public static class HelperMethods
    {
        public static int? ReturnEnum<T>(List<T> enums)
        {

            for (int i = 0; i < enums.Count; i++)
            {
                Console.WriteLine($"{i + 1} {enums[i]}");
            }
            int? answer = Console.ReadLine().Parsing();
            if (answer == 0 || answer > enums.Count)
            {
                throw new ExceptionService("Invalid message type");
            }
            return answer;
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
            Console.WriteLine("Enter username");
            string? message = Console.ReadLine();
            char[] characters = message.ToCharArray();
            int count = 0;
            foreach (char c in characters)
            {
                count++;
            }
            if (count >= 5)
            {
                return message;
            }
            throw new ExceptionService("Username must contain atleats 5 characters");
        }

        //method to check the passoword when the new user is added, if the password is atleast 5 chars and has atleast one number
        public static string CountCharPassword()
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
                throw new ExceptionService("Password must contain atleats 5 characters and a number");
            }
            return message;
        }



        public static int? Parsing(this string input)
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

        public static void MainMenu()
        {
            Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
            Console.ReadLine();
            Console.Clear();
        }

    }

}
