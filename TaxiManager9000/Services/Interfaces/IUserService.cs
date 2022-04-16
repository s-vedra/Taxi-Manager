using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        User Login();
        void AddNewUser();
        User RemoveUser();
        void ChangePassword(User user);
        void PrintUsers();
    }
}
