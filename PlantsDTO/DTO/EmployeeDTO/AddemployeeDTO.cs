using System;
using System.Collections.Generic;
using System.Text;
using PlantsDAL.Validations.Employee;

namespace PlantsDTO.DTO.EmployeeDTO
{
    public class AddemployeeDTO
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string address1 { get; set; }
		[Employeeaddressvalidation]
		public string address2 { get; set; }
		//[EmployeeBDValidation]
		public DateTime Birthdate { get; set; }
		public string role { get; set; }
	}
}
