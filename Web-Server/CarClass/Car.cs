using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClass
{
    public class Car
    {
        public Car()
        {
            CarID = 1;
            Directions = 'S';
        }

        /// <summary>
        /// CarID will be used to hold an int that represents the ID of the Car connecting to the WebAPI
        /// </summary>
        public int CarID { get; set; }

        /// <summary>
        /// Directions will be used to hold a char that represents the Direction the car is supposed to move in
        /// </summary>
        public char Directions { get; set; }
    }
}
