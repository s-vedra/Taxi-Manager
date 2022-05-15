using Enums;
using Models;
using Services.Interfaces;

namespace Services
{
    public class ManagerService : IManagerService
    {

        //assigning the cars to the drivers by ID
        public void AssignCarsToDrivers()
        {
            DBServices<Driver>.AssignEntity(1, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(1, EntitiesDB.cars);
            DBServices<Driver>.AssignEntity(2, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(1, EntitiesDB.cars);
            DBServices<Driver>.AssignEntity(3, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(2, EntitiesDB.cars);
            DBServices<Driver>.AssignEntity(4, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(3, EntitiesDB.cars);
            DBServices<Driver>.AssignEntity(5, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(3, EntitiesDB.cars);
            DBServices<Driver>.AssignEntity(6, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(2, EntitiesDB.cars);
            DBServices<Driver>.AssignEntity(7, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(5, EntitiesDB.cars);
            DBServices<Driver>.AssignEntity(8, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(3, EntitiesDB.cars);
            DBServices<Driver>.AssignEntity(9, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(5, EntitiesDB.cars);
            DBServices<Driver>.AssignEntity(10, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(6, EntitiesDB.cars);
            DBServices<Driver>.AssignEntity(11, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(1, EntitiesDB.cars);
            DBServices<Driver>.AssignEntity(12, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(4, EntitiesDB.cars);
        }

        public void ListAllDrivers<T>(List<T> drivers) where T : BaseEntity
        {
            DBServices<T>.PrintEntities(drivers, (drivers) => drivers.ForEach(driver => Console.WriteLine(driver.PrintInfo(), HelperMethods.ChangeColor(ConsoleColor.White))));
        }


        public void PrintTaxiLicenseStatus()
        {
            EntitiesDB.drivers.ForEach(driver => Console.WriteLine(driver.PrintLicenseStatus()));
        }

        public void UnassignDriver()
        {
            Console.WriteLine("Assigned Drivers:");
            List<Driver> assignedDrivers = EntitiesDB.drivers.Where(driver => driver.Shift != Shift.NotAssigned).ToList();
            ListAllDrivers(assignedDrivers);
            Driver driver = DBServices<Driver>.ReturnEntity(assignedDrivers);
            driver.Shift = Shift.NotAssigned;
            driver.Car = null;
            Console.Clear();
            Console.WriteLine($"{driver.PrintInfo()}");
        }

        public void AssignDriver()
        {
            Console.WriteLine("Unassigned Drivers:");
            List<Driver> unassignedDrivers = EntitiesDB.drivers.Where(driver => driver.Shift == Shift.NotAssigned).ToList();
            ListAllDrivers(unassignedDrivers);
            Driver driver = DBServices<Driver>.ReturnEntity(unassignedDrivers);
            Shift shift = ReturnShift();

            //get the assigned cars first and then create a list for all the cars that aren't in the first list
            List<Car> assignedCars = EntitiesDB.cars.Where(car => car.AssignedDrivers.Where(driver => driver.Shift == shift).ToList().Count > 0).ToList();
            List<Car> availableCars = EntitiesDB.cars.Except(assignedCars).Where(car => car.ReturnLicense() != "Expired").ToList();

            driver.Shift = shift;
            Console.Clear();
            Console.WriteLine($"Available cars for {shift} shift");

            ListAllDrivers(availableCars);

            driver.Car = DBServices<Car>.ReturnEntity(availableCars);
            Console.Clear();
            Console.WriteLine(driver.PrintInfo());
        }

        public static Shift ReturnShift()
        {
            Console.Clear();
            Console.WriteLine("Choose shift: ");
            return (Shift)HelperMethods.ReturnEnum(EntitiesDB.shifts);
        }
    }
}
