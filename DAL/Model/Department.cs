using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        //navigation property
        public virtual ICollection<Employee>? Employees { get; set; }=new HashSet<Employee>();

    }
}
