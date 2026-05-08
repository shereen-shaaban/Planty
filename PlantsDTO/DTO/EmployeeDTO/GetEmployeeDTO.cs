using System;
using System.Collections.Generic;
using System.Text;

namespace PlantsDTO.DTO.EmployeeDTO
{
    public class GetEmployeeDTO
    {
		public string Name { get; set; }
		public string address1 { get; set; }
		public string address2 { get; set; }
		public DateTime Birthdate { get; set; }
		public string role { get; set; }
	}
}
