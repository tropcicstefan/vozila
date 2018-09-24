using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vozila
{
    class PersonLicense
    {
        public Person Person { get; set; }
        public List<DriversLicense> Licenses = new List<DriversLicense>();

        public PersonLicense(Person person, DriversLicense license)
        {
            Person = person;
            Licenses.Add(license);
        }
        public void AddDriversLicense(DriversLicense license)
        {
            Licenses.Add(license);
        }

    }
}
