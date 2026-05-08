using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlantsDAL.Validations.Employee
{
    internal class EmployeeBDValidation:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var bd = (DateTime)value;
            if (bd >= DateTime.Now)
                return false;
            else
                return true;

        }
    }
}
