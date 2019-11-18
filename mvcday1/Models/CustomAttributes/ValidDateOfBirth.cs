using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcday1.Models.CustomAttributes
{
    public class ValidDateOfBirth:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.Birthdate >= DateTime.Now)
            {
                return new ValidationResult("Birth Date should be not greater than todays date");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}