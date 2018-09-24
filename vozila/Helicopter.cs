using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vozila
{
    class Helicopter : Vehicle, Flying
    {
        public int NumberOfBlades { get; set; }

        public string BladesType { get; set; }

        public int AirborneTime
        {
            get => AirborneTime;
            set => AirborneTime = 5;
        }

        public Helicopter(string name, int tonnage, int numberOfPeople, string color, int numberOfBlades, string bladesType) : base(name, tonnage, numberOfPeople, color)
        {
            NumberOfBlades = numberOfBlades;
            BladesType = bladesType;
        }


    }
}
