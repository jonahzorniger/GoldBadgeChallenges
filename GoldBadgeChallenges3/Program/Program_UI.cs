using ObjectClass;
using Program_UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Program_UI
    {
        private readonly BadgeDoorDatabase _badgeDoorDatabase;

        public Program_UI()
        {
            _badgeDoorDatabase = new BadgeDoorDatabase();
        } 

        public void Run()
        {
            RunApplication();
        }

        public void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Komodo Insurance!!\n" +
                    "Please enter a number to perform one of the following: \n\n" +
                    "1. Create a new badge\n" +
                    "2. Update doors on an existing badge\n" +
                    "3. Show a list with all badge numbers and door access\n" +
                    "4. Delete all doors from an existing badge");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        UpdateDoorOnBadge();
                        break;
                    case "3":
                        ViewAllBadges();
                        break;
                    case "4":
                        DeleteAllDoorsFromBadge();
                        break;
                    default:
                        Console.WriteLine(userInput + " is a invalid input please try again");
                        Console.ReadLine();
                        break;
                }
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
            }
        }
        
        private void AddABadge()
        {
            Console.WriteLine("You have selected to add a badge!");
            Console.WriteLine("What is the badge number?");
            int inputBadgeID = Convert.ToInt32(Console.ReadLine());

            List<string> inputDoors = new List<string>();
            string response = "y";

            while(response == "y")
            {
                Console.WriteLine("Enter the door that Badge #" + inputBadgeID + " needs access to:");
                string doorName = Console.ReadLine();
                inputDoors.Add(doorName);
                Console.WriteLine("Any other doors (y/n)?");
                response = Console.ReadLine();
            }

            Badge badgeToAdd = new Badge(inputBadgeID, inputDoors);
            _badgeDoorDatabase.AddBadge(badgeToAdd);
        }

        private void UpdateDoorOnBadge() //Done
        {
            Console.WriteLine("What is the badge number to update?");
            int inputBadgeId = Convert.ToInt32(Console.ReadLine());
            Badge currentBadge = _badgeDoorDatabase.GetBadge(inputBadgeId);
            List<string> doorsOnBadge;
            if (currentBadge != null)
            {
                doorsOnBadge = currentBadge.DoorList;
                Console.WriteLine(inputBadgeId + " has access to doors" + string.Join(",", currentBadge.DoorList));
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Remove a door \n" +
                                  "2. Add a door");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Which door would you like to remove?");
                        string doorToRemove = Console.ReadLine();
                        doorsOnBadge.Remove(doorToRemove);
                        Console.WriteLine(inputBadgeId + " has access to doors" + string.Join(",", currentBadge.DoorList));
                        break;
                    case "2":
                        Console.WriteLine("Which door would you like to add?");
                        string doorToAdd = Console.ReadLine();
                        doorsOnBadge.Add(doorToAdd);
                        Console.WriteLine(inputBadgeId + " has access to doors" + string.Join(",", currentBadge.DoorList));
                        break;
                }

            }
            else
            {
                Console.WriteLine(inputBadgeId + " does not exist");
            }      
        }

        private void ViewAllBadges() //Done
        {
            Console.WriteLine("All badge data is listed below:");
            Console.WriteLine("Badge ID:      Door Access:");

            Dictionary<int, List<string>> badges = _badgeDoorDatabase.GetBadges();
            foreach (KeyValuePair<int, List<string>> badge in badges)
            {
                Console.WriteLine($"{badge.Key}      {string.Join(",", badge.Value)}");
            }
        }

        private void DeleteAllDoorsFromBadge() //Done
        {
            Console.WriteLine("You have chosen to Delete All Doors from a badge");
            Console.WriteLine("Please enter the badge ID number");
            int inputBadgeID = Convert.ToInt32(Console.ReadLine());
            Badge updatedBadge = _badgeDoorDatabase.GetBadge(inputBadgeID);
            if (updatedBadge != null)
            {
                updatedBadge.DoorList = new List<string>();
                _badgeDoorDatabase.UpdateBadge(inputBadgeID, updatedBadge);
            }
            else
            {
                Console.WriteLine(inputBadgeID + " does not exist.");
            }
        }
    }
}
