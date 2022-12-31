using Newtonsoft.Json;
namespace mis321pa1
{
    public class FileHandler
    {
        public List<Driver> drivers;

        public FileHandler(){
            GetAllData();
            
        }

        private void GetAllData(){
            
            try{
                string json = File.ReadAllText("drivers.txt");
                drivers = JsonConvert.DeserializeObject<List<Driver>>(json);

                
            }

            catch(FileNotFoundException e){
                Console.WriteLine(e.Message);
                System.Console.WriteLine("Creating file...");
                using (var brackets = File.CreateText("drivers.txt"))
                    {
                        brackets.WriteLine("[]");
                    }
            }




        }
        public void SaveAll(){
            File.WriteAllText("drivers.txt", JsonConvert.SerializeObject(drivers));
        }
    }
}
