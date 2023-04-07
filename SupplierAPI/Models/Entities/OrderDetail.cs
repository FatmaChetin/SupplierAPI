using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplierAPI.Models.Entities
{
    public class OrderDetail:BaseEntity
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal SubTotalPrice { get; set; }
        public short Quantity { get; set; }

        //relational properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

    }
}