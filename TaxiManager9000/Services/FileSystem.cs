using Models;

namespace Services
{
    public class FileSystem
    {
       
        public FileSystem()
        {
            FileSystemDB<User> dataUsers = new FileSystemDB<User>();
            FileSystemDB<Driver> dataDrivers = new FileSystemDB<Driver>();
            FileSystemDB<Car> dataCar = new FileSystemDB<Car>();
            FileSystemDB<User>.SerializeEntities(EntitiesDB.users);
            FileSystemDB<Car>.SerializeEntities(EntitiesDB.cars);
            FileSystemDB<Driver>.SerializeEntities(EntitiesDB.drivers);

        }

    }
}
