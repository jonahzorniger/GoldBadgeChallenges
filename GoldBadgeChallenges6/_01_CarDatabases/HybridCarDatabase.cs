using CarObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CarDatabases
{
    public class HybridCarDatabase
    {
        private readonly List<Car> _hybridCarDatabase = new List<Car>();

        //Create
        public void AddHybridCar(Car hybridCarToAdd)
        {
            _hybridCarDatabase.Add(hybridCarToAdd);
        }

        //Read
        public Car GetHybridCar(string carType)
        {
            foreach(Car hybridCar in _hybridCarDatabase)
            {
                if(hybridCar.CarType == carType)
                {
                    return hybridCar;
                }
            }
            return null;
        }

        //Update
        public bool UpdateHybridCar(string typedHybridCar, Car updatedCar)
        {
            Car oldCar = GetHybridCar(typedHybridCar);
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
        public void DeleteHybridCar(string carType)
        {
            Car hybridCarToDelete = null;
            foreach (Car hybridCar in _hybridCarDatabase)
            {
                if(hybridCar.CarType == carType)
                {
                    hybridCarToDelete = hybridCar;
                }
            }
            if(hybridCarToDelete != null)
            {
                _hybridCarDatabase.Remove(hybridCarToDelete);
            }
            
            
            
        }
        public List<Car> GetAllHybridCars()
        {
            return _hybridCarDatabase;
        }
    }
}
