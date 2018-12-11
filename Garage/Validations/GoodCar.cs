using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Garage.Models;

namespace Garage.Validations
{
    public class GoodCar : ValidationAttribute
    {
        public GoodCar() { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            CarCreateViewModel model = (CarCreateViewModel)validationContext.ObjectInstance;

            if (model.Manufacturer != "Fiat")
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(GetErrorMessage());
        }

        private string GetErrorMessage()
        {
            return "Car must NOT be a Fiat; only good cars";
        }
    }
}
