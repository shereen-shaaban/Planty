using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Validations
{
    public class Namecategoryvalidation:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("in valid name musn't to be null");
            }
            string name = value.ToString();
            if(name.Length<5)
                return new ValidationResult($"invalid name length must be more than 5 .");
            return ValidationResult.Success;
        }
    }

}
