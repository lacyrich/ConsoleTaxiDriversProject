namespace mis321pa1
{
    public class Utility
    {
        public List<Driver> drivers;

        private FileHandler fileHandler = new FileHandler();
        public Utility(){
            drivers = fileHandler.drivers;
        }

        public void HireNewDriver(){
            Driver newDriver = new Driver();
            System.Console.WriteLine("What is the driver's name?");
            newDriver.Name = Console.ReadLine();
            System.Console.WriteLine("What model is the driver's vehicle?");
            newDriver.EmployeeVehicle.Model = Console.ReadLine();
            drivers.Add(newDriver);
            Save();
        }
        public void DisplayDrivers(){
                SortAllDrivers();
                Console.Clear();
                System.Console.WriteLine("Jeff's Drivers");
                foreach(Driver driver in drivers){
                System.Console.WriteLine(driver.ToString());
            }
        }

        public void UpdateDriverRating(){
            DisplayDrivers();
            System.Console.WriteLine("Enter the name of the driver whose rating you would like to edit.");
            string userInput = Console.ReadLine();
            Driver driver = FindDriver(userInput);
            if(driver == null){
                System.Console.WriteLine("Driver not found.");
            }else{
                System.Console.WriteLine("What should the driver's rating be?\nPlease enter a number between 0 and 5");
                driver.Rating = int.Parse(Console.ReadLine());
                while(driver.Rating > 5 || driver.Rating < 0)
                {
                    System.Console.WriteLine("Invalid rating. Please enter a number between 0 and 5 ");
                    driver.Rating = int.Parse(Console.ReadLine());
                }
                Save();
            }
            
            
        }

        public void FireDriver(){
            DisplayDrivers();
            System.Console.WriteLine("Enter the ID of the driver you would like to fire:");
            System.Guid userInput = System.Guid.Parse(Console.ReadLine()); 
            Driver driver = FindEmployeeID(userInput);
            if(driver == null){
                System.Console.WriteLine("Driver employee ID not found.");
            }else{
                drivers.Remove(driver);
            }
            Save();
        }
        private Driver FindDriver(string searchVal){
            Driver returnVal = drivers.Find(x => x.Name.ToLower() == searchVal.ToLower());
            return returnVal;
        }

        private Driver FindEmployeeID(System.Guid searchVal){
            Driver returnVal = drivers.Find(x => x.EmployeeID == searchVal); 
            return returnVal;
        }
        private void Save(){
            fileHandler.SaveAll();
        }

        private void SortAllDrivers(){

            System.Console.WriteLine("Enter 1 to sort by date hired\nEnter 2 to sort by rating");
            string userInput = Console.ReadLine();
            while(userInput != "1" && userInput != "2")
            {
                System.Console.WriteLine("Invalid choice, please try again");
                System.Console.WriteLine("Enter 1 to sort by date hired\nEnter 2 to sort by rating");
                userInput = Console.ReadLine();
            }
            if(userInput == "1")
            {
                drivers.Sort((y,x) => x.DateHired.CompareTo(y.DateHired));
            }
            
            else if(userInput == "2")
            {
                drivers.Sort((y,x) => x.Rating.CompareTo(y.Rating));
            }

        }

         private void SortByMaintenanceDate(){
            drivers.Sort((x,y) => x.EmployeeVehicle.MaintenanceDate.CompareTo(y.EmployeeVehicle.MaintenanceDate));
        }

          public void ViewMaintenanceDate()
        {
            Console.Clear();
            System.Console.WriteLine("Maintenance Date By Month");
            SortByMaintenanceDate();
            int monthTotal = 1;
            int currMonth = drivers[0].EmployeeVehicle.MaintenanceDate.Month;
            string currMonthName = drivers[0].EmployeeVehicle.MaintenanceDate.ToString("MMMM");
            System.Console.WriteLine(drivers[0].EmployeeVehicle.ToString());
            for(int i = 1; i < drivers.Count; i++)
            {
                if(drivers[i].EmployeeVehicle.MaintenanceDate.Month == currMonth)
                {
                    System.Console.WriteLine(drivers[i].EmployeeVehicle.ToString());
                    monthTotal ++;
                    
                }
                else
                {
                    ProcessMonthBreak(ref currMonth, ref currMonthName, ref monthTotal, i);
                    System.Console.WriteLine(drivers[i].EmployeeVehicle.ToString());
                }
            }
            ProcessMonthBreak(ref currMonth, ref currMonthName, ref monthTotal, 0);
 
        }

        private void ProcessMonthBreak(ref int currMonth, ref string currMonthName, ref int monthTotal, int i){
            System.Console.WriteLine($"The Total Vehicles Scheduled for Maintenance in {currMonthName} is {monthTotal} ");
            currMonthName = drivers[i].EmployeeVehicle.MaintenanceDate.ToString("MMMM");
            currMonth = drivers[i].EmployeeVehicle.MaintenanceDate.Month;
            monthTotal = 1;
        }
    }
}