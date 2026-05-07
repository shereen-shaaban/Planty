using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime paydate { get; set; }


        //forign keys
        public int Customerid { get; set; }

        //navigation property
        public virtual Customer? customer { get; set; }
    }
}
