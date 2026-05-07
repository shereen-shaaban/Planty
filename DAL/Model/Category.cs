using System;
using System.Collections.Generic;
using System.Text;
using DAL.Validations;

namespace DAL.Model
{
    public class Category
    {
        //properties
        public int Id { get; set; }
        [Namecategoryvalidation]
        public string Name { get; set; }
        public string Description { get; set; }

        //navigation property
        public virtual ICollection<Product>? Products { get; set; }=new HashSet<Product>();
    }
}
