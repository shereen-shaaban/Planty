using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlantsDAL.Validations.Employee
{
    public class Employeeaddressvalidation:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string address2 = value.ToString();
            var obj = validationContext.ObjectInstance;
            var add1 = validationContext.ObjectType.GetProperty("address1").GetValue(obj)?.ToString();
            if (add1 == address2)
                return new ValidationResult("invalid two address is same");
            else 
                return ValidationResult.Success;

		}
    }
}
