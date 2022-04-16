using System.Text.RegularExpressions;
using Models;
namespace Services
{
    public static class HelperMethods
    {
        //method used to increment the ID number when adding a new user
        public static int ReturnId<T>(List<T> entities) where T : BaseEntity
        {
            int count = 1;
            foreach (T entity in entities)
            {
                count++;
            }
            return count;
        }

        //method to change the text color in the console
        public static ConsoleColor ChangeColor(ConsoleColor color)
        {
            return Console.ForegroundColor = color;
        }

        //method to count the number of chars in the username when the new user is added
        public static bool CountCharUsername(string input)
        {
            char[] characters = input.ToCharArray();
            int count = 0;
            foreach (char c in characters)
            {
                count++;
            }
            if (count < 5)
            {
                return false;
            }
            return true;
        }

        //method to check the passoword when the new user is added, if the password is atleast 5 chars and has atleast one number
        public static bool CountCharPassword(string input)
        {
            Regex hasNumber = new Regex(@"[0-9]+");
            char[] characters = input.ToCharArray();
            int count = 0;
            foreach (char c in characters)
            {
                count++;    
            }
            if (!hasNumber.IsMatch(input) || count < 5)
            {
                return false;
            }
            return true;

        }
        public static int Parsing(string input)
        {
            while (true)
            {
                try
                {
                    if (!int.TryParse(input, out int num))
                    {
                        throw new Exception("Invalid input");
                    }
                    else
                    {
                        return num;
                    }
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                    return 0;
                }
            }
        }
    }

}
