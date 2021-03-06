﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Garage.Validations;

namespace Garage.Models
{
    public class CarCreateViewModel
    {
        [Required]
        [GoodCar]
        public string Manufacturer { get; set; }
        public bool MOT { get; set; }

        [Display(Name = "Driver")]
        public int SelectedDriverId { get; set; }
        public IEnumerable<SelectListItem> Drivers { get; set; }
    }
}