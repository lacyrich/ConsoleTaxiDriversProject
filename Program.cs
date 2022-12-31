using mis321pa1;

Utility utils = new Utility();
Menu menu = new Menu();

string userInput = menu.GetMainMenuChoice();
while(userInput != "6"){
    RouteEm(userInput);
    userInput = menu.GetMainMenuChoice();
}

void RouteEm(string userInput){
    switch (userInput){
        case "1":
            utils.DisplayDrivers();
            break;
        case "2":
            utils.HireNewDriver();
            break;
        case "3":
            utils.UpdateDriverRating();
            break;
        case "4":
            utils.FireDriver();
            break;
        case "5":
            utils.ViewMaintenanceDate();
            break;
        default:
            System.Console.WriteLine("Bad entry");
            break;
    }
}
