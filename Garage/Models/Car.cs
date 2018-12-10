using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Models
{
    public class Car
    {
        public int CarID { get; set; }
        public string Manufacturer { get; set; }
        public bool MOT { get; set; }

        public int DriverID { get; set; }
        public Driver Driver { get; set; }
    }
}
