namespace mis321pa1
{
    public class Vehicle  
    {
        public System.Guid VehicleID {get; set;}
        public string Model {get; set;}
        public System.DateTime MaintenanceDate {get; set;}

        public static int Count {get; set;}

        public Vehicle(){
            VehicleID = System.Guid.NewGuid();
            Model = "";
            MaintenanceDate = System.DateTime.Now.AddMonths(6);
            Count = 0;
        }

        public override string ToString()
        {

            return $"ID: {VehicleID} \t Model: {Model} \t Maintenance Date: {MaintenanceDate.ToString("MM/dd/yyyy")}";
        }
    }
}