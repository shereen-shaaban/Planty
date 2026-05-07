using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class OrderProduct
    {
        //properties
        public int Id { get; set; }
        public int amount { get; set; }

        // forign keys
        public int Productid { get; set; }
        public int Orderid { get; set; }


        // navgation property
        public virtual Product? Product { get; set; }
        public virtual Order? Order { get; set; }

    }
}
