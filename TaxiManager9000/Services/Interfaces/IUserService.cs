using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.UserService;

namespace Services.Interfaces
{
    public interface IUserService
    {
        User Login();
        void AddNewUser(ReturnPassword returnPassword, ReturnUsername returnUsername);
        void RemoveUser(int id);
        void ChangePassword(User user);
    }
}
