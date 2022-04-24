using Enums;
using Models;
using Services;

UserService userService = new UserService();
ManagerService managerService = new ManagerService();
MaintenanceService maintenanceService = new MaintenanceService();

managerService.AssignCarsToDrivers();
maintenanceService.AssignedDrivers();

Console.WriteLine("Taxi Manager 9000");
User user = userService.Login();
while (true)
{
    switch (user.Role)
    {
        case Role.Administrator:
            Console.WriteLine("1.Add a user \n2.Remove a user \n3.Change your password \n4.Exit", HelperMethods.ChangeColor(ConsoleColor.White));
            int answerAdmin = HelperMethods.Parsing(Console.ReadLine());
            switch (answerAdmin)
            {
                case 1:

                    Console.Clear();
                    userService.AddNewUser();
                    Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                case 2:
                    Console.Clear();
                    userService.PrintUsers();
                    User userToRemove = userService.RemoveUser();
                    if (user.CheckID(userToRemove))
                    {
                        Console.WriteLine("You can't do that!");
                        continue;
                    }
                    else
                    {
                        Console.Clear();
                        DBServices<User>.Remove(EntitiesDB.users, userToRemove);
                        Console.WriteLine($"{userToRemove.Username} successfully removed", HelperMethods.ChangeColor(ConsoleColor.Green));
                        userService.PrintUsers();
                        Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                case 3:
                    Console.Clear();
                    userService.ChangePassword(user);
                    Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
                    Console.ReadLine();
                    Console.Clear();
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
            int answerMain = HelperMethods.Parsing(Console.ReadLine());
            switch (answerMain) 
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Vehicles:");
                    maintenanceService.ListVehicles();
                    Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                case 2:
                    Console.Clear();
                    maintenanceService.ListLicenseStatus();
                    Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                case 3:
                    Console.Clear();
                    userService.ChangePassword(user);
                    Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
                    Console.ReadLine();
                    Console.Clear();
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
            int answerManager = HelperMethods.Parsing(Console.ReadLine());
            switch (answerManager)
            {
                case 1:
                    Console.Clear();
                    managerService.ListAllDrivers();
                    Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                case 2:
                    Console.Clear();
                    managerService.PrintTaxiLicenseStatus();
                    Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                case 3:
                    Console.Clear();
                    Console.WriteLine("1.Assign a Driver \n2.Unassign a Driver");
                    int answer = HelperMethods.Parsing(Console.ReadLine());
                    switch (answer) 
                    {
                        case 1:
                            Console.Clear();
                            managerService.AssignDriver();
                            Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                        case 2:
                            Console.Clear();
                            managerService.UnassignDriver();
                            Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
                            Console.ReadLine();
                            Console.Clear();
                            continue;
                    }
                    continue;
                case 4:
                    Console.Clear();
                    userService.ChangePassword(user);
                    Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
                    Console.ReadLine();
                    Console.Clear();
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


