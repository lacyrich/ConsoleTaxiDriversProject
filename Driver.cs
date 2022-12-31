namespace mis321pa1
{
    public class Driver 
    {
        public System.Guid EmployeeID {get; set;}
        public string Name {get; set;}
        public System.DateTime DateHired {get; set;}
        public int Rating {get; set;}
        public Vehicle EmployeeVehicle {get; set;}
        public Driver (){
            EmployeeID = System.Guid.NewGuid();
            DateHired = System.DateTime.Now;
            Name = "";
            Rating = 0;
            EmployeeVehicle = new Vehicle();
            
        }
        public override string ToString()
        {
            return $"ID: {EmployeeID}\tName: {Name}\tDate Hired: {DateHired}\tRating: {Rating}/5";
        }
    }
}