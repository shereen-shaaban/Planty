using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Customer
    {
        //properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string phone { get; set; }
        public string Address { get; set; }

        //navigation properties

        public virtual ICollection<Order>? Orders { get; set; }=new HashSet<Order>();
        public virtual ICollection<Payment>? Payments { get; set; } = new HashSet<Payment>();
    }
}
