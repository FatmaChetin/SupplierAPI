using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SupplierAPI.Models.Entities;
using SupplierAPI.Models.Init;

namespace SupplierAPI.Models.Context
{
	public class MyContext : DbContext
	{
		public MyContext() : base("MyConnection")
		{
			Database.SetInitializer(new MyInit());
		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{

			modelBuilder.Entity<OrderDetail>().Ignore(x => x.ID).HasKey(x => new
			{
				x.OrderID,
				x.ProductID
			});
		}
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }

	}
}