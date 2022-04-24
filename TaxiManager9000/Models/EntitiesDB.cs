using Enums;
namespace Models
{
    public static class EntitiesDB
    {
        public static List<User> users = new List<User>()
        {
            new User(1,"BobAdmin","bobAdmin12345", Role.Administrator),
            new User(2,"JackMain","jackMain12345",Role.Maintenance),
            new User(3,"JillManager","jillManager12345", Role.Manager),
            new User(4,"admin","admin", Role.Administrator)
        };

        public static List<Driver> drivers = new List<Driver>()
        {
            new Driver(1, "Bob", "Bobsky", Shift.Afternoon,  "ABCD1E", new DateTime(2022, 6, 17)),
            new Driver(2, "Jack", "Jacsky", Shift.Morning, "ABCD2E", new DateTime(2022, 6, 19)),
            new Driver(3, "Gary", "Kris", Shift.Morning,  "AFCD3E", new DateTime(2022, 3, 1)),
            new Driver(4, "Lola", "Lolsky", Shift.Afternoon,  "FFFD6E", new DateTime(2022, 9, 20)),
            new Driver(5, "Jenn", "Jennsky", Shift.Evening,  "AAAC1E", new DateTime(2022, 1, 5)),
            new Driver(6, "Adam", "Adamsky", Shift.Evening,  "ABPP1E", new DateTime(2023, 2, 6)),
            new Driver(7, "Eliot", "Eliotsky", Shift.Afternoon,  "MMMD9E", new DateTime(2023, 6, 17)),
            new Driver(8, "Jack", "Jacsky", Shift.Morning, "DDDD4P", new DateTime(2023, 6, 19)),
            new Driver(9, "Alex", "Alexsky", Shift.Morning,  "OPLD5E", new DateTime(2023, 3, 1)),
            new Driver(10, "Rona", "Ronsky", Shift.Afternoon,  "POTD5R", new DateTime(2023, 9, 20)),
            new Driver(11, "Dex", "Dexsky", Shift.Evening,  "BBBC3E", new DateTime(2021, 12, 5)),
            new Driver(12, "Wayne", "Waynsky", Shift.Evening,  "LLLP6M", new DateTime(2022, 2, 6)),
            new Driver(13, "Gwen", "Ten", Shift.NotAssigned, "DDMD4P", new DateTime(2024, 6, 19)),
            new Driver(14,"Emerson", "Rollins", Shift.NotAssigned,  "PPLD5E", new DateTime(2023, 2, 1)),
            new Driver(15, "Amelia", "Moody", Shift.NotAssigned,  "PORD5R", new DateTime(2023, 5, 21)),
            new Driver(16, "Emilie", "Horn", Shift.NotAssigned,  "BLBC3E", new DateTime(2021, 8, 6)),
            new Driver(17, "Nathen", "Higgins", Shift.NotAssigned,  "LLLA6M", new DateTime(2022, 12, 5)),
        };

        public static List<Car> cars = new List<Car>()
        {
           new Car(1, "Toyota Auris", "335CO1", new DateTime(2022, 12, 31)),
           new Car(2, "Peugeot 208", "284FH8", new DateTime(2023, 2, 15)),
           new Car(3, "Ford Focus", "123AB6", new DateTime(2021, 11, 28)),
           new Car(4, "Audi A2", "908MM9", new DateTime(2024, 12, 27)),
           new Car(5, "Mazda 6", "555DE1", new DateTime(2021, 12, 15)),
           new Car(6, "Opel Corsa", "333CA2", new DateTime(2022, 6, 17)),
        };
    }
}
