using CarObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CarDatabases
{
    public class ElectricCarDatabase
    {
        private readonly List<Car> _electricCarDatabase = new List<Car>();


        //Create
        public void AddElectricCar(Car electricCarToAdd)
        {
            _electricCarDatabase.Add(electricCarToAdd);
        }
        
        //Read
        public Car GetElectricCar(string carType)
        {
            foreach(Car electricCar in _electricCarDatabase)
            {
                if(electricCar.CarType == carType)
                {
                    return electricCar;
                }
            }
            return null;
        }
        //Update

        public bool UpdateElectricCar(string typedCarName, Car updatedCar)
        {
            Car oldCar = GetElectricCar(typedCarName);
            if (oldCar != null)
            {
                oldCar.Name = updatedCar.Name;
                oldCar.CarType = updatedCar.CarType;
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
        
        
        
        //Delete
        public void DeleteElectricCar(string carName)
        {
            Car electricCarToDelete = null;
            foreach (Car electricCar in _electricCarDatabase)
            {
                if(electricCar.Name == carName)
                {
                    electricCarToDelete = electricCar;
                }
            }
            if(electricCarToDelete != null)
            {
                _electricCarDatabase.Remove(electricCarToDelete);
            }
        }

        //Get all electric cars
        public List<Car> GetAllElectricCars()
        {
            return _electricCarDatabase;
        }
    }
}
