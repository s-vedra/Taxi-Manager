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
            DBServices<Driver>.ReturnEntity(1, EntitiesDB.drivers).Car = DBServices<Car>.ReturnEntity(1, EntitiesDB.cars);
            DBServices<Driver>.ReturnEntity(2, EntitiesDB.drivers).Car = DBServices<Car>.ReturnEntity(1, EntitiesDB.cars);
            DBServices<Driver>.ReturnEntity(3, EntitiesDB.drivers).Car = DBServices<Car>.ReturnEntity(2, EntitiesDB.cars);
            DBServices<Driver>.ReturnEntity(4, EntitiesDB.drivers).Car = DBServices<Car>.ReturnEntity(3, EntitiesDB.cars);
            DBServices<Driver>.ReturnEntity(5, EntitiesDB.drivers).Car = DBServices<Car>.ReturnEntity(3, EntitiesDB.cars);
            DBServices<Driver>.ReturnEntity(6, EntitiesDB.drivers).Car = DBServices<Car>.ReturnEntity(2, EntitiesDB.cars);
            DBServices<Driver>.ReturnEntity(7, EntitiesDB.drivers).Car = DBServices<Car>.ReturnEntity(5, EntitiesDB.cars);
            DBServices<Driver>.ReturnEntity(8, EntitiesDB.drivers).Car = DBServices<Car>.ReturnEntity(3, EntitiesDB.cars);
            DBServices<Driver>.ReturnEntity(9, EntitiesDB.drivers).Car = DBServices<Car>.ReturnEntity(5, EntitiesDB.cars);
            DBServices<Driver>.ReturnEntity(10, EntitiesDB.drivers).Car = DBServices<Car>.ReturnEntity(6, EntitiesDB.cars);
            DBServices<Driver>.ReturnEntity(11, EntitiesDB.drivers).Car = DBServices<Car>.ReturnEntity(1, EntitiesDB.cars);
            DBServices<Driver>.ReturnEntity(12, EntitiesDB.drivers).Car = DBServices<Car>.ReturnEntity(4, EntitiesDB.cars);
        }

        public void ListAllDrivers()
        {
            DBServices<Driver>.PrintEntities(EntitiesDB.drivers);
        }

        public void PrintTaxiLicenseStatus()
        {
            EntitiesDB.drivers.ForEach(driver => Console.WriteLine(driver.PrintLicenseStatus()));
        }

        public void UnassignDriver()
        {
            Console.WriteLine("Assigned Drivers:");
            List<Driver> assignedDrivers = EntitiesDB.drivers.Where(driver => driver.Shift != Shift.NotAssigned).ToList();
            DBServices<Driver>.PrintEntities(assignedDrivers);
            Driver driver = DBServices<Driver>.HandleException(assignedDrivers);
            driver.Shift = Shift.NotAssigned;
            driver.Car = null;
            Console.Clear();
            Console.WriteLine($"{driver.PrintInfo()}");
        }

        public void AssignDriver()
        {
            Console.WriteLine("Unassigned Drivers:");
            List<Driver> unassignedDrivers = EntitiesDB.drivers.Where(driver => driver.Shift == Shift.NotAssigned).ToList();
            DBServices<Driver>.PrintEntities(unassignedDrivers);
            Driver driver = DBServices<Driver>.HandleException(unassignedDrivers);
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter shift: \n1.Morning \n2.Afternoon \n3.Evening");
                    int shiftInput = HelperMethods.Parsing(Console.ReadLine());
                    if (shiftInput > 3 || shiftInput == 0)
                    {
                        throw new Exception("Please choose 1-3");
                    }
                    else
                    {
                        Shift shift = (Shift)shiftInput;

                        //get the assigned cars first and then create a list for all the cars that aren't in the first list
                        List<Car> assignedCars = EntitiesDB.cars.Where(car => car.AssignedDrivers.Where(driver => driver.Shift == shift).ToList().Count > 0).ToList();
                        List<Car> availableCars = EntitiesDB.cars.Except(assignedCars).ToList();

                        driver.Shift = shift;
                        Console.Clear();
                        Console.WriteLine($"Available cars for {shift} shift");

                        //list available cars
                        availableCars.Where(car => car.ReturnLicense() != "Expired").ToList()
                        .ForEach(car => Console.WriteLine(car.PrintInfo(), HelperMethods.ChangeColor(ConsoleColor.White))); 

                        Car chosenCar = DBServices<Car>.HandleException(availableCars);
                        Console.Clear();
                        driver.Car = chosenCar;
                        Console.WriteLine(driver.PrintInfo());
                    }

                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                    continue;
                }
                break;
            }

        }
    }
}
