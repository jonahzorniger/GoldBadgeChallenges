using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarObject
{
    //Type of car
    //Name of the car
    public class Car
    {
        public Car() { }

        public Car
            (string name,
            string carType)
        {
            Name = name;
            CarType = carType;
        }
        //unique identifier
        public string Name { get; set; }
        public string CarType { get; set; }
    }
}
