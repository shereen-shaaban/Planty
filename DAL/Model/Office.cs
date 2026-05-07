using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Office
    {
        //properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        //navigation prperty
        public virtual ICollection<Employee>? Employees { get; set; } = new HashSet<Employee>();
    }
}
