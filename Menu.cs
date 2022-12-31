namespace mis321pa1
{
    public class Menu
    {
        private void DisplayMainMenu(){
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            System.Console.WriteLine("1. Show all drivers");
            System.Console.WriteLine("2. Hire a new driver");
            System.Console.WriteLine("3. Update driver’s rating");
            System.Console.WriteLine("4. Fire a driver by EmployeeID");
            System.Console.WriteLine("5. View Maintenance Date By Month");
            System.Console.WriteLine("6. Exit the App");
        }

        public string GetMainMenuChoice(){
            DisplayMainMenu();
            System.Console.WriteLine("Enter Menu Choice");
            return Console.ReadLine();
        }
    }
}