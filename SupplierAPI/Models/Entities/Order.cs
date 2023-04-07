using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplierAPI.Models.Entities
{
	public class Order : BaseEntity
	{
		public string ShippingAddress { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime? DeliveryDate { get; set; }
		public bool Delivered { get; set; } // Teslim Edildi mi ?



		public int? CustomerID { get; set; }

		//relational properties

		public virtual Customer Customer { get; set; }
		public virtual List<OrderDetail> OrderDetails { get; set; }
	}
}