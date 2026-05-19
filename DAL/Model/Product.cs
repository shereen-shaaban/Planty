using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Product
    {
        //properties
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int quanity { get; set; }
        public string Image { get; set; }


        // forign keys
        public int Cid { get; set; }

        //navigation property
        public virtual Category? category {get;set; }

        public virtual ICollection<OrderProduct>? OrdersProduct { get; set; }=new HashSet<OrderProduct>();


    }
}
