using Enums;
using Models.Interfaces;

namespace Models
{
    public class User : BaseEntity, IUser
    {
        public string Username { get; set; }
        private string Password { get; set; }
        public Role Role { get; set; }

        public User(int id, string username, string password, Role role) : base(id)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        //this method is used when the user wants to remove someone, if he accidentally sends his own ID
        public bool CheckID(User user)
        {
            if (user.Id == Id)
            {
                return true;
            }
            return false;
        }
        public bool CheckPassword(string password)
        {

            if (Password == password)
            {
                return true;
            }
            return false;
        }

        public bool CheckUsername(string username)
        {

            if (Username == username)
            {
                return true;
            }
            return false;
        }

        public bool ChangePassword(string password)
        {
            if (Password == password)
            {
                return false;
            }
            return true;
        }
        public override string PrintInfo()
        {
            return $"{Id} {Username} {Role}";
        }
    }
}