using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class Order
    {
        //properties
        public int Id { get; set; }
        public string status { get; set; }

        public DateTime Bookdate { get; set; }
    
		public DateTime wantdate { get; set; }
		//public DateTime delevirdate { get; set; }


        //forign keys
        public int Customerid { get; set; }

        //navigation properties
        public  virtual ICollection<OrderProduct>? OrderProducts { get; set; }=new HashSet<OrderProduct>();
        public virtual Customer? Customer { get; set; }

	}
}
