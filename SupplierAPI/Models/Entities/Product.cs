using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplierAPI.Models.Entities
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }

        


        //relational properties
        public virtual Category Category { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
