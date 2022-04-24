using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IManagerService
    {
        void AssignCarsToDrivers();
        void ListAllDrivers();
        void PrintTaxiLicenseStatus();
        void UnassignDriver();
        void AssignDriver();
        
    }
}
