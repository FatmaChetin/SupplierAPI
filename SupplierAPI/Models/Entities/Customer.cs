using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplierAPI.Models.Entities
{
    public class Customer:BaseEntity
    {
        public string CompanyName { get; set; }
        public string ContactNumber { get; set; }
        public string  ShippingAddress { get; set; }
        public string ShippingCity { get; set;}

        //relational properties
        public virtual List<Order> Orders { get; set; }
    }
}