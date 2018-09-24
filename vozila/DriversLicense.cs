using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vozila
{
    class DriversLicense
    {
        public int IdNumber { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string CategoryType { get; set; }

        private List<string> CategoryList = new List<string> { "pilot", "driver" };

        public DriversLicense(int idNumber, int category, DateTime expiryDate)
        {
            IdNumber = idNumber;
            CategoryType = CategoryList[category];
            ExpiryDate = expiryDate;
        }
    }
}
