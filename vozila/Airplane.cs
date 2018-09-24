using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vozila
{
    class Airplane : Vehicle, Flying
    {
        public int NumberOfMotors { get; set; }

        public string WingsType { get; set; }

        public int AirborneTime
        {
            get => AirborneTime;
            set => AirborneTime = 100;
        }

        public Airplane(string name, int tonnage, int numberOfPeople, string color, int numberOfMotors, string wingsType) : base(name, tonnage, numberOfPeople, color)
        {
            NumberOfMotors = numberOfMotors;
            WingsType = wingsType;
        }
    }
}
