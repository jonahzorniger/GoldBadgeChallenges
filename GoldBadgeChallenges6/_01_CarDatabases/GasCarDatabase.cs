using CarObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CarDatabases
{
    public class GasCarDatabase
    {
        private readonly List<Car> _gasCarDatabase = new List<Car>();

        //Create
        public void AddGasCar(Car GasCarToAdd)
        {
            _gasCarDatabase.Add(GasCarToAdd);
        }

        //Read
        public Car GetGasCar(string carType)
        {
            foreach(Car gasCar in _gasCarDatabase)
            {
                if(gasCar.CarType == carType)
                {
                    return gasCar;
                }
            }
            return null;
        }
        //Update
        public bool UpdateGasCar(string typedCarName, Car updatedCar)
        {
            Car oldCar = GetGasCar(typedCarName);
            if(oldCar != null)
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
        public void DeleteGasCar(string carType)
        {
            Car gasCarToDelete = null;
            foreach (Car gasCar in _gasCarDatabase)
            {
                if(gasCar.CarType == carType)
                {
                    gasCarToDelete = gasCar;
                }
            }
            if(gasCarToDelete != null)
            {
                _gasCarDatabase.Remove(gasCarToDelete);
            }
        }

        public List<Car> GetAllGasCars()
        {
            return _gasCarDatabase;
        }
    }
}
