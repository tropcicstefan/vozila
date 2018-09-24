using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vozila
{
    abstract class Vehicle
    {
        public string Name { get; set; }

        public int Tonnage { get; set; }

        public int NumberOfPeople { get; set; }

        public string Color { get; set; }


        public Vehicle(string name, int tonnage, int numberOfPeople, string color)
        {
            Name = name;
            Tonnage = tonnage;
            NumberOfPeople = numberOfPeople;
            Color = color;
        }
    }
}
