using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using PlantsDAL.Validations.Employee;

namespace DAL.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string address1{ get; set; }
        [Employeeaddressvalidation]
        public string address2{ get; set; }
        [EmployeeBDValidation]
        public DateTime Birthdate { get; set; }
        public string role { get; set; }
        //[NotMapped]
        //public int age { get; set; } = DateTime.Now - Birthdate;

        //forign keys
        public int? managerid { get; set; }

        public int Officeid     { get; set; }

        public int Did { get; set; }
        //navigation property
        public virtual Office? office { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; } = new HashSet<Employee>();
        public virtual Employee? Manager { get; set; }
        public virtual Department? Department { get; set; }






	}
}
