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
            DBServices<Driver>.AssignEntity(1, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(1, EntitiesDB.cars).Id;
            DBServices<Driver>.AssignEntity(2, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(1, EntitiesDB.cars).Id;
            DBServices<Driver>.AssignEntity(3, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(2, EntitiesDB.cars).Id;
            DBServices<Driver>.AssignEntity(4, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(3, EntitiesDB.cars).Id;
            DBServices<Driver>.AssignEntity(5, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(3, EntitiesDB.cars).Id;
            DBServices<Driver>.AssignEntity(6, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(2, EntitiesDB.cars).Id;
            DBServices<Driver>.AssignEntity(7, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(5, EntitiesDB.cars).Id;
            DBServices<Driver>.AssignEntity(8, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(3, EntitiesDB.cars).Id;
            DBServices<Driver>.AssignEntity(9, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(5, EntitiesDB.cars).Id;
            DBServices<Driver>.AssignEntity(10, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(6, EntitiesDB.cars).Id;
            DBServices<Driver>.AssignEntity(11, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(1, EntitiesDB.cars).Id;
            DBServices<Driver>.AssignEntity(12, EntitiesDB.drivers).Car = DBServices<Car>.AssignEntity(4, EntitiesDB.cars).Id;
        }

        public void ListAllDrivers<T>(List<T> drivers) where T : BaseEntity
        {
            FileSystemDB<T>.PrintEntities(drivers, (drivers) => drivers.ForEach(driver => Console.WriteLine(driver.PrintInfo(), HelperMethods.ChangeColor(ConsoleColor.White))));
        }


        public void PrintTaxiLicenseStatus()
        {
            FileSystemDB<Driver>.DeserializeEntities()?.ForEach(driver => Console.WriteLine(driver.PrintLicenseStatus()));
        }

        public void UnassignDriver()
        {
            Console.WriteLine("Assigned Drivers:");
            List<Driver> assignedDrivers = EntitiesDB.drivers.Where(driver => driver.Shift != Shift.NotAssigned).ToList();
            ListAllDrivers(assignedDrivers);
            Driver driver = HelperMethods.ReturnEntity(assignedDrivers);
            driver.Shift = Shift.NotAssigned;
            driver.Car = null;
            Console.Clear();
            FileSystemDB<Driver>.PrintEntity(driver);
        }

        private List<Car> ReturnAvailableCars(Shift shift)
        {
            List<Car> assignedCars = FileSystemDB<Car>.DeserializeEntities().Where(car => car.AssignedDrivers
            .Where(driver => FileSystemDB<Driver>.ReturnEntityById(driver, FileSystemDB<Driver>.DeserializeEntities()).Shift == shift).ToList().Count() > 0).ToList();
            return FileSystemDB<Car>.DeserializeEntities().Except(assignedCars).Where(car => car.ReturnLicense() != "Expired").ToList();
        }

        public void AssignDriver()
        {
            Console.WriteLine("Unassigned Drivers:");
            List<Driver> unassignedDrivers = EntitiesDB.drivers.Where(driver => driver.Shift == Shift.NotAssigned).ToList();
            ListAllDrivers(unassignedDrivers);
            Driver driver = HelperMethods.ReturnEntity(unassignedDrivers);
            Shift shift = ReturnShift();
            List<Car> availableCars = ReturnAvailableCars(shift);
            driver.Shift = shift;
            Console.Clear();
            Console.WriteLine($"Available cars for {shift} shift");
            ListAllDrivers(availableCars);
            Console.WriteLine("Enter id: ");
            int? id = Console.ReadLine().Parsing();
            driver.Car = FileSystemDB<Car>.ReturnEntityById(id, availableCars).Id;
            Console.Clear();
            FileSystemDB<Driver>.PrintEntity(driver);
        }

        public static Shift ReturnShift()
        {
            Console.Clear();
            while (true)
            {
                try
                {

                    Console.WriteLine("Choose shift: ");
                    return (Shift)HelperMethods.ReturnEnum(EntitiesDB.shifts);
                }
                catch (ExceptionService msg)
                {
                    Console.WriteLine(msg.Error);
                    continue;
                }
            }

        }
    }
}
