using Enums;
using Models.Interfaces;
using System.Text.RegularExpressions;

namespace Models
{
    public class Driver : BaseEntity, IDriver
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Shift Shift { get; set; }
        public int? Car { get; set; }
        public string License { get; set; }
        public DateTime LicenseExpieryDate { get; set; }

        public Driver(int id, string firstName, string lastName, Shift shift, string license, DateTime licenseExpiary) : base(id)
        {

            FirstName = firstName;
            LastName = lastName;
            Shift = shift;
            License = license;
            LicenseExpieryDate = licenseExpiary;

        }

        public string ReturnLicense()
        {
            int result = DateTime.Compare(LicenseExpieryDate, DateTime.Now);
            TimeSpan difference = LicenseExpieryDate - DateTime.Now;

            if (difference.Days < 90 && difference.Days > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                return $"Will expire on{LicenseExpieryDate: dd/MM/yyyy}";
            }
            else if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                return $"Valid, expires on{LicenseExpieryDate: dd/MM/yyyy}";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return $"Expired on{LicenseExpieryDate: dd/MM/yyyy}";
            }
        }
        public override string PrintInfo()
        {
            if (Car == null)
            {
                return $"{Id} {FirstName} {LastName} Shift: {Regex.Replace(Shift.ToString(), "(?<=[a-z])([A-Z])", " $1", RegexOptions.Compiled)} Car: No assigned Car";
            }
        
            return $"{Id} {FirstName} {LastName} Shift: {Shift} Car: {EntitiesDB.cars.Single(car => car.Id == Car).Model}";
        }
        public string PrintLicenseStatus()
        {
            return $"{PrintInfo()} License status: {ReturnLicense()}";
        }
    }
}
