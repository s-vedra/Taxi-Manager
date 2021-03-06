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
        double ReturnPercent(int car);
        void ListVehicles(List<Car> cars);
        void AssignedDrivers();
        void ListLicenseStatus(List<Car> cars);
    }
}
