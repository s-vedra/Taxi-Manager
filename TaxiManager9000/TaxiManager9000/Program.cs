using Enums;
using Models;
using Services;
using Services.Interfaces;

IUserService userService = new UserService();
IManagerService managerService = new ManagerService();
IMaintenanceService maintenanceService = new MaintenanceService();

managerService.AssignCarsToDrivers();
maintenanceService.AssignedDrivers();

Console.WriteLine("Taxi Manager 9000");
User user = userService.Login();
while (true)
{
    try
    {
        switch (user.Role)
        {
            case Role.Administrator:
                Console.WriteLine("1.Add a user \n2.Remove a user \n3.Change your password \n4.Exit", HelperMethods.ChangeColor(ConsoleColor.White));
                int? answerAdmin = HelperMethods.Parsing(Console.ReadLine());
                switch (answerAdmin)
                {
                    case 1:
                        Console.Clear();
                        userService.AddNewUser(HelperMethods.CountCharPassword, HelperMethods.CountCharUsername);
                        HelperMethods.MainMenu();
                        continue;
                    case 2:
                        Console.Clear();
                        Console.Clear();
                        userService.RemoveUser(user.Id);
                        HelperMethods.MainMenu();
                        continue;
                    case 3:
                        Console.Clear();
                        userService.ChangePassword(user);
                        HelperMethods.MainMenu();
                        continue;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Please choose 1-4", HelperMethods.ChangeColor(ConsoleColor.Red));
                        continue;
                }
                break;

            case Role.Maintenance:
                Console.WriteLine("1.See vehicles \n2.See License Plate Status \n3.Change your password \n4.Exit", HelperMethods.ChangeColor(ConsoleColor.White));
                int? answerMain = HelperMethods.Parsing(Console.ReadLine());
                switch (answerMain)
                {
                    case 1:
                        Console.Clear();
                        maintenanceService.ListVehicles(EntitiesDB.cars);
                        HelperMethods.MainMenu();
                        continue;
                    case 2:
                        Console.Clear();
                        maintenanceService.ListLicenseStatus(EntitiesDB.cars);
                        HelperMethods.MainMenu();
                        continue;
                    case 3:
                        Console.Clear();
                        userService.ChangePassword(user);
                        HelperMethods.MainMenu();
                        continue;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Please choose 1-4", HelperMethods.ChangeColor(ConsoleColor.Red));
                        continue;
                }
                break;
            case Role.Manager:
                Console.WriteLine("1.See all drivers \n2.See Taxi License Status \n3.Driver Manager \n4.Change your password \n5.Exit", HelperMethods.ChangeColor(ConsoleColor.White));
                int? answerManager = HelperMethods.Parsing(Console.ReadLine());
                switch (answerManager)
                {
                    case 1:
                        Console.Clear();
                        managerService.ListAllDrivers(EntitiesDB.drivers);
                        HelperMethods.MainMenu();
                        continue;
                    case 2:
                        Console.Clear();
                        managerService.PrintTaxiLicenseStatus();
                        HelperMethods.MainMenu();
                        continue;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("1.Assign a Driver \n2.Unassign a Driver");
                        int? answer = HelperMethods.Parsing(Console.ReadLine());
                        switch (answer)
                        {
                            case 1:
                                Console.Clear();
                                managerService.AssignDriver();
                                HelperMethods.MainMenu();
                                continue;
                            case 2:
                                Console.Clear();
                                managerService.UnassignDriver();
                                HelperMethods.MainMenu();
                                continue;
                            default:
                                Console.WriteLine("Please choose 1-2", HelperMethods.ChangeColor(ConsoleColor.Red));
                                continue;
                        }
                    case 4:
                        Console.Clear();
                        userService.ChangePassword(user);
                        HelperMethods.MainMenu();
                        continue;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Please choose 1-5", HelperMethods.ChangeColor(ConsoleColor.Red));
                        continue;
                }

                break;
        }
        break;
    }
    catch (ExceptionService msg)
    {
        Console.WriteLine(msg.Error);
        continue;
    }
    
}


