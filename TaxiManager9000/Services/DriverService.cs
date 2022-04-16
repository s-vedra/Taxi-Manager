using Models;
using Services.Interfaces;

namespace Services
{
    public class DriverService : IDriverService
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
            DBServices<Driver>.ReturnEntity(10,EntitiesDB.drivers).Car = DBServices<Car>.ReturnEntity(6, EntitiesDB.cars);
            DBServices<Driver>.ReturnEntity(11,EntitiesDB.drivers).Car = DBServices<Car>.ReturnEntity(1, EntitiesDB.cars);
            DBServices<Driver>.ReturnEntity(12,EntitiesDB.drivers).Car = DBServices<Car>.ReturnEntity(4, EntitiesDB.cars);
        }

        public void ListAllDrivers()
        {
            DBServices<Driver>.PrintEntities(EntitiesDB.drivers);
        }

        public void PrintTaxiLicenseStatus()
        {
            foreach (Driver driver in EntitiesDB.drivers)
            {
                Console.WriteLine(driver.PrintLicenseStatus());
            }
        }
    }
}
