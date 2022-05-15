using Enums;
using Models.Interfaces;

namespace Models
{
    public class User : BaseEntity, IUser
    {
        public string Username { get; set; }
        private string _password { get; set; }
        public Role Role { get; set; }

        public User(int id, string username, string password, Role role) : base(id)
        {
            Username = username;
            _password = password;
            Role = role;
        }

        public bool CheckPassword(string password)
        {

            if (_password == password)
            {
                return true;
            }
            return false;
        }


        public bool ChangePassword(string password)
        {
            if (_password == password)
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