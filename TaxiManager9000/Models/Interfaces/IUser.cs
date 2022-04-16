using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IUser
    {
        bool CheckPassword(string password);
        bool CheckUsername(string username);
        bool ChangePassword(string password);
    }
}
