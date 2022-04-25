using Models;
using Services.Interfaces;

namespace Services
{
    public class MaintenanceService : IMaintenanceService
    {

        //every car's own list of assigned drivers by ID
        public void AssignedDrivers()
        {
            DBServices<Car>.ReturnEntity(1, EntitiesDB.cars).AssignedDrivers = new List<Driver>()
            {
              DBServices<Driver>.ReturnEntity(1, EntitiesDB.drivers),
              DBServices<Driver>.ReturnEntity(2, EntitiesDB.drivers),
              DBServices<Driver>.ReturnEntity(11, EntitiesDB.drivers)
            };
            DBServices<Car>.ReturnEntity(2, EntitiesDB.cars).AssignedDrivers = new List<Driver>()
            {
              DBServices<Driver>.ReturnEntity(3, EntitiesDB.drivers),
              DBServices<Driver>.ReturnEntity(6, EntitiesDB.drivers),
            };
            DBServices<Car>.ReturnEntity(3, EntitiesDB.cars).AssignedDrivers = new List<Driver>()
            {
              DBServices<Driver>.ReturnEntity(4, EntitiesDB.drivers),
              DBServices<Driver>.ReturnEntity(5, EntitiesDB.drivers),
              DBServices<Driver>.ReturnEntity(8, EntitiesDB.drivers)
            };
            DBServices<Car>.ReturnEntity(4, EntitiesDB.cars).AssignedDrivers = new List<Driver>()
            {
              DBServices<Driver>.ReturnEntity(12, EntitiesDB.drivers),
            };
            DBServices<Car>.ReturnEntity(5, EntitiesDB.cars).AssignedDrivers = new List<Driver>()
            {
              DBServices<Driver>.ReturnEntity(7, EntitiesDB.drivers),
              DBServices<Driver>.ReturnEntity(9, EntitiesDB.drivers),
            };
            DBServices<Car>.ReturnEntity(6, EntitiesDB.cars).AssignedDrivers = new List<Driver>()
            {
              DBServices<Driver>.ReturnEntity(10, EntitiesDB.drivers),
            };
        }

        //method to return the percent of how many shifts do the cars cover -> 100% all 3 shifts, 67% -> 2 shifts and 33 -> 1 only one shift
        public double ReturnPercent(Car car)
        {
            double count = 0;
            foreach (Driver driver in EntitiesDB.drivers)
            {

                if (driver.Car == car)
                {
                    count++;
                }

            }
            return Math.Round((count / 3) * 100, 0);
        }

        public void ListVehicles()
        {
            EntitiesDB.cars.ForEach(car => Console.WriteLine($"{car.PrintInfo()} covers {ReturnPercent(car)}% of shifts", HelperMethods.ChangeColor(ConsoleColor.White)));
        }
        public void ListLicenseStatus()
        {
            EntitiesDB.cars.ForEach(car => Console.WriteLine(car.PrintLicenseStatus()));
        }
    }
}
