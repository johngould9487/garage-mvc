using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Garage.Models
{
    public class CarEditViewModel
    {
        public string Manufacturer { get; set; }
        public bool MOT { get; set; }

        public int CarID { get; set; }

        [Display(Name = "Driver")]
        public int SelectedDriverId { get; set; }
        public IEnumerable<SelectListItem> Drivers { get; set; }
    }
}