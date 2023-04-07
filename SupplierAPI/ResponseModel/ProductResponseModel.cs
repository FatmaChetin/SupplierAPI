using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplierAPI.ResponseModel
{
	public class ProductResponseModel
	{
		public int ID { get; set; }
		public string ProductName { get; set; }
		public decimal UnitPrice { get; set; }
		public int Amount { get; set; }
	}
}