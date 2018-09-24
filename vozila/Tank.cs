using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vozila
{
    class Tank : Vehicle, Driving
    {
        public int LengthOfBarrel { get; set; }

        public string GrenadeType { get; set; }

        public int DrivingTime
        {
            get => DrivingTime;
            set => DrivingTime = 80;
        }
        public Tank(string name, int tonnage, int numberOfPeople, string color, int lengthOfBarrel, string grenadeType) : base(name, tonnage, numberOfPeople, color)
        {
            LengthOfBarrel = lengthOfBarrel;
            GrenadeType = grenadeType;
        }
    }
}
