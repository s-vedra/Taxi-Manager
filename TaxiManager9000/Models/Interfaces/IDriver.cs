using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IDriver
    {
        string ReturnLicense();
        string PrintLicenseStatus();
    }
}
