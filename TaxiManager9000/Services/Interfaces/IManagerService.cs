using Enums;
using Models;
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
        void PrintTaxiLicenseStatus();
        void UnassignDriver();
        void AssignDriver();
        void ListAllDrivers<T>(List<T> drivers) where T : BaseEntity;


    }
}
