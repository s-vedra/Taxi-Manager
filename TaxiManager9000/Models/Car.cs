using Models.Interfaces;
namespace Models
{
    public class Car : BaseEntity, ICar
    {
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public DateTime LicensePlateExpieryDate { get; set; }
        public List<Driver> AssignedDrivers = new List<Driver>();

        public Car(int id, string model, string licensePlate, DateTime expiaryDate) : base(id)
        {
            Model = model;
            LicensePlate = licensePlate;
            LicensePlateExpieryDate = expiaryDate;
        }

        public string ReturnLicense()
        {
            int result = DateTime.Compare(LicensePlateExpieryDate, DateTime.Now);
            TimeSpan difference = LicensePlateExpieryDate - DateTime.Now;

            if (difference.Days < 90 && difference.Days > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                return $"Will expire on {LicensePlateExpieryDate.ToString("MM/dd/yyyy")}";
            }
            else if (result > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                return "Valid";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Expired";
            }
        }

        public override string PrintInfo()
        {
            return $"{Id} {Model} {LicensePlate}";
        }
        public string PrintLicenseStatus()
        {
            return $"{PrintInfo()} License status: {ReturnLicense()}";
        }
    }
}
