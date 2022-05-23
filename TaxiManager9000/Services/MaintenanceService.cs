using Models;
using Services.Interfaces;

namespace Services
{
    public class MaintenanceService : IMaintenanceService
    {
        //every car's own list of assigned drivers by ID
        public void AssignedDrivers()
        {
            DBServices<Car>.AssignEntity(1, EntitiesDB.cars).AssignedDrivers = new List<int>()
            {
              DBServices<Driver>.AssignEntity(1, EntitiesDB.drivers).Id,
              DBServices<Driver>.AssignEntity(2, EntitiesDB.drivers).Id,
              DBServices<Driver>.AssignEntity(11, EntitiesDB.drivers).Id
            };
            DBServices<Car>.AssignEntity(2, EntitiesDB.cars).AssignedDrivers = new List<int>()
            {
              DBServices<Driver>.AssignEntity(3, EntitiesDB.drivers).Id,
              DBServices<Driver>.AssignEntity(6, EntitiesDB.drivers).Id,
            };
            DBServices<Car>.AssignEntity(3, EntitiesDB.cars).AssignedDrivers = new List<int>()
            {
              DBServices<Driver>.AssignEntity(4, EntitiesDB.drivers).Id,
              DBServices<Driver>.AssignEntity(5, EntitiesDB.drivers).Id,
              DBServices<Driver>.AssignEntity(8, EntitiesDB.drivers).Id
            };
            DBServices<Car>.AssignEntity(4, EntitiesDB.cars).AssignedDrivers = new List<int>()
            {
              DBServices<Driver>.AssignEntity(12, EntitiesDB.drivers).Id,
            };
            DBServices<Car>.AssignEntity(5, EntitiesDB.cars).AssignedDrivers = new List<int>()
            {
              DBServices<Driver>.AssignEntity(7, EntitiesDB.drivers).Id,
              DBServices<Driver>.AssignEntity(9, EntitiesDB.drivers).Id,
            };
            DBServices<Car>.AssignEntity(6, EntitiesDB.cars).AssignedDrivers = new List<int>()
            {
              DBServices<Driver>.AssignEntity(10, EntitiesDB.drivers).Id,
            };
        }

        //method to return the percent of how many shifts do the cars cover -> 100% all 3 shifts, 67% -> 2 shifts and 33 -> 1 only one shift
        public double ReturnPercent(int car)
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

        public void ListVehicles(List<Car> cars)
        {
            Console.WriteLine("Vehicles:");
            FileSystemDB<Car>.PrintEntities(cars, (cars) => 
            cars.ForEach(car => Console.WriteLine($"{car.PrintInfo()} covers {ReturnPercent(car.Id)}% of shifts", HelperMethods.ChangeColor(ConsoleColor.White))));
        }
        public void ListLicenseStatus(List<Car> cars)
        {
            FileSystemDB<Car>.PrintEntities(cars,(cars) => cars.ForEach(car => Console.WriteLine(car.PrintLicenseStatus())));
        }
    }
}
