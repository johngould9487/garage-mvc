using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage.Models
{
    public class DriverDetailsViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
