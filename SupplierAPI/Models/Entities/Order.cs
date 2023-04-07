using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplierAPI.Models.Entities
{
    public class Order:BaseEntity
    {
        public short HowManyRequested { get; set; }// ne kadar istenildiği bilgisi isteniyor
        public decimal TotalPrice { get; set; }
        public int? CustomerID { get; set; }

        //relational properties

        public virtual Customer Customer { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}