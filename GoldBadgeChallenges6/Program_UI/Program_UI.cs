using _01_CarDatabases;
using CarObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_UI
{
    public class Program_UI
    {
        private readonly ElectricCarDatabase _electricDataBase;
        private readonly GasCarDatabase _gasDatabase;
        private readonly HybridCarDatabase _hybridDatabase;

        public Program_UI()
        {
            _electricDataBase = new ElectricCarDatabase();
            _gasDatabase = new GasCarDatabase();    
            _hybridDatabase = new HybridCarDatabase();
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
                    "Please enter a car name to perform one of the following: \n\n" +
                    "1. Add a Car\n" +
                    "2. View Electric Cars\n" +
                    "3. View Gas Cars\n" +
                    "4. View Hybrid Cars\n" +
                    "5. Update an Existing Car\n" +
                    "6. Delete an Existing Car\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddACar();
                        break;
                    case "2":
                        ViewElectricCars();
                        break;
                    case "3":
                        ViewGasCars();
                        break;
                    case "4":
                        ViewHybridCars();
                        break;
                    case "5":
                        //UpdateAnExistingCar();
                        break;
                    case "6":
                        DeleteAnExistingCar();
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

        private void DeleteAnExistingCar()
        {
            Console.WriteLine("You have selected to Delete a car!");
            Console.WriteLine("Please enter the type of car:");
            string carType = (Console.ReadLine());
            Console.WriteLine("Please enter the name of the car:");
            string carName = (Console.ReadLine());

            switch (carType)
            {
                case "Electric Car":
                    _electricDataBase.DeleteElectricCar(carName);
                    Console.WriteLine($"You have deleted an {carName} electric car!");
                    break;
                case "Gas Car":
                    _gasDatabase.DeleteGasCar(carName);
                    Console.WriteLine($"You have deleted an {carName}  gas car!");
                    break;
                case "Hybrid Car":
                    _hybridDatabase.DeleteHybridCar(carName);
                    Console.WriteLine($"You have deleted an {carName} hybrid car!");
                    break;
                default:
                    Console.WriteLine("Invalid Type");
                    break;

            }

        }

        private void UpdateAnExistingCar()
        {
            Console.WriteLine("You have selected to update a car");
            Console.WriteLine("Please enter the type of car");
            string carType = Console.ReadLine();
            Console.WriteLine("Please enter the name of the car.");
            string existingCarName = Console.ReadLine();
            Console.WriteLine("Please enter the new name of the car");
            string newCarName = Console.ReadLine();

            switch (carType)
            {
                case "Electric Car":
                    Car existingElectricCar = _electricDataBase.GetElectricCar(existingCarName);
                    existingElectricCar.Name = newCarName;
                    _electricDataBase.UpdateElectricCar(existingCarName, existingElectricCar);
                    Console.WriteLine($"You have updated {existingCarName} electric car!");
                    break;
                case "Gas Car":
                    Car existingGasCar = _gasDatabase.GetGasCar(existingCarName);
                    existingGasCar.Name = newCarName;
                    _electricDataBase.UpdateElectricCar(existingCarName, existingGasCar);
                    Console.WriteLine($"You have updated{existingCarName} gas car!");
                    break;
                case "Hybrid Car":
                    Car existingHybridCar = _hybridDatabase.GetHybridCar(existingCarName);
                    existingHybridCar.Name = newCarName;
                    _hybridDatabase.UpdateHybridCar(existingCarName, existingHybridCar);
                    Console.WriteLine($"You have updated {existingCarName} hybrid car!");
                    break;
                default:
                    Console.WriteLine("Invalid Type");
                    break;
            }
        }

        private void ViewHybridCars()
        {
            List<Car> existingHybridCars = _hybridDatabase.GetAllHybridCars();
            foreach (Car car in existingHybridCars)
            {
                Console.WriteLine("Car Name: " + " " + car.Name + "Car Type: " + car.CarType);
            }
        }

        private void ViewGasCars()
        {
            List<Car> existingGasCars = _gasDatabase.GetAllGasCars();
            foreach (Car car in existingGasCars)
            {
                Console.WriteLine("Car Name: " + " " + car.Name + "Car Type: " + car.CarType);
            }
        }

        private void ViewElectricCars()
        { 
            List<Car> existingElectricCars = _electricDataBase.GetAllElectricCars();
            foreach(Car car in existingElectricCars)
            {
                Console.WriteLine("Car Name: " + " " + car.Name + "Car Type: " + car.CarType);
            }
        }

        private void AddACar()
        {
            Console.WriteLine("You have selected to add a car!");
            Console.WriteLine("Please enter the type of car:");
            string carType = (Console.ReadLine());
            Console.WriteLine("Please enter the name of the car:");
            string carName = (Console.ReadLine());

            switch (carType)
            {
                case "Electric Car":
                    Car electricCarToAdd = new Car(carType, carName);
                     _electricDataBase.AddElectricCar(electricCarToAdd);
                     Console.WriteLine("You have added a new electric car!");
                    break;
                case "Gas Car":
                    Car gasCarToAdd = new Car(carType, carName);
                    _gasDatabase.AddGasCar(gasCarToAdd);
                    Console.WriteLine("You have added a new gas car!");
                    break;
                case "Hybrid Car":
                    Car hybridCarToAdd = new Car(carType, carName);
                    _hybridDatabase.AddHybridCar(hybridCarToAdd);
                    Console.WriteLine("You have added a new hybrid car!");
                    break;
                default:
                    Console.WriteLine("Invalid Type");
                    break;

            }
        }
    }
}
