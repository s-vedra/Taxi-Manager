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
    if (user.Role == Role.Administrator)
    {
        
        Console.WriteLine("1.Add a user \n2.Remove a user \n3.Change your password \n4.Exit", HelperMethods.ChangeColor(ConsoleColor.White));
        int answer = HelperMethods.Parsing(Console.ReadLine());
        if (answer == 1)
        {
            Console.Clear();
            userService.AddNewUser();
            Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
            Console.ReadLine();
            Console.Clear();
            continue;
        }
        else if (answer == 2)
        {
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
        }
        else if (answer == 3)
        {
            Console.Clear();
            userService.ChangePassword(user);
            Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
            Console.ReadLine();
            Console.Clear();
            continue;
        }
        else if (answer == 4)
        {
            Console.Clear();
            Console.WriteLine("Goodbye!");
            break;
        }
        else
        {
            Console.WriteLine("Please choose 1-4", HelperMethods.ChangeColor(ConsoleColor.Red));
            continue;
        }
    }
    else if (user.Role == Role.Maintenance)
    {
        Console.WriteLine("1.See vehicles \n2.See License Plate Status \n3.Change your password \n4.Exit", HelperMethods.ChangeColor(ConsoleColor.White));
        int answer = HelperMethods.Parsing(Console.ReadLine());
        if (answer == 1)
        {
            Console.Clear();
            Console.WriteLine("Vehicles:");
            maintenanceService.ListVehicles();
            Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
            Console.ReadLine();
            Console.Clear();
            continue;
        }
        else if (answer == 2)
        {
            Console.Clear();
            maintenanceService.ListLicenseStatus();
            Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
            Console.ReadLine();
            Console.Clear();
            continue;
        } else if (answer == 3)
        {
            Console.Clear();
            userService.ChangePassword(user);
            Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
            Console.ReadLine();
            Console.Clear();
            continue;
        }
        else if (answer == 4)
        {
            Console.Clear();
            Console.WriteLine("Goodbye!");
            break;
        }
        else
        {
            Console.WriteLine("Please choose 1-3", HelperMethods.ChangeColor(ConsoleColor.Red));
            continue;
        }
    }
    else if (user.Role == Role.Manager)
    {
        Console.WriteLine("1.See all drivers \n2.See Taxi License Status \n3.Driver Manager \n4.Change your password \n5.Exit", HelperMethods.ChangeColor(ConsoleColor.White));
        int answer = HelperMethods.Parsing(Console.ReadLine());
        if (answer == 1)
        {
            Console.Clear();
            managerService.ListAllDrivers();
            Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
            Console.ReadLine();
            Console.Clear();
            continue;
        }
        else if (answer == 2)
        {
            Console.Clear();
            managerService.PrintTaxiLicenseStatus();
            Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
            Console.ReadLine();
            Console.Clear();
            continue;
        } 
        else if (answer == 4)
        {
            Console.Clear();
            userService.ChangePassword(user);
            Console.WriteLine("Press enter to go back to Main Menu", HelperMethods.ChangeColor(ConsoleColor.Magenta));
            Console.ReadLine();
            Console.Clear();
            continue;
        }
        else if (answer == 5)
        {
            Console.Clear();
            Console.WriteLine("Goodbye!");
            break;
        }
    }
    break;
}

