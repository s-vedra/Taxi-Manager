using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMaintenanceService
    {
        double ReturnPercent(Car car);
        void ListVehicles();
        void AssignedDrivers();
        void ListLicenseStatus();
    }
}
