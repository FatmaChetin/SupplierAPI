using Bogus.DataSets;
using SupplierAPI.Models.Context;
using SupplierAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SupplierAPI.Models.Init
{
	public class MyInit : CreateDatabaseIfNotExists<MyContext>
	{
		protected override void Seed(MyContext context)
		{
			for (int i = 0; i < 20; i++)
			{
				Product p = new Product();

				p.ProductName = new Commerce("tr").ProductName();
				p.UnitPrice = Convert.ToDecimal(new Commerce("tr").Price());

				p.Amount = 100;
				context.Products.Add(p);
				context.SaveChanges();
			}

		}
	}
}