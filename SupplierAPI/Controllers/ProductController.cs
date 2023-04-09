using SupplierAPI.DesignPattern.SingletonPattern;
using SupplierAPI.Models.Context;
using SupplierAPI.Models.Entities;

using SupplierAPI.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Http;

namespace SupplierAPI.Controllers
{
	public class ProductController : ApiController
	{
		MyContext _db;
		public ProductController()
		{
			_db = DBTool.DbInstance;
		}

		private List<ProductResponseModel> ListProducts()
		{
			return _db.Products.Select(x => new ProductResponseModel
			{
				ID = x.ID,
				ProductName = x.ProductName,
				UnitPrice = x.UnitPrice,
				Amount = x.Amount,
			}).ToList();
		}
		[HttpGet]

		public List<ProductResponseModel> GetProducts()
		{
			return ListProducts();
		}

		[HttpPost]
		public List<ProductResponseModel> AddProduct(ProductResponseModel item)
		{
			Product p = new Product
			{
				ProductName = item.ProductName,
				UnitPrice = item.UnitPrice,
				Amount = item.Amount,


			};
			_db.Products.Add(p);
			_db.SaveChanges();
			return ListProducts();
		}
		[HttpPut]
		public List<ProductResponseModel> UpdateProduct(ProductResponseModel item)
		{
			Product toBeUpdated = _db.Products.Find(item.ID);

			toBeUpdated.ProductName = item.ProductName;
			toBeUpdated.UnitPrice = item.UnitPrice;
			toBeUpdated.Amount = item.Amount;
			_db.SaveChanges();
			return ListProducts();
		}
		[HttpDelete]
		public List<ProductResponseModel> DeleteProduct(int id)
		{
			_db.Products.Remove(_db.Products.Find(id));
			_db.SaveChanges();
			return ListProducts();
		}

		[HttpGet]
		public List<ProductResponseModel> SearchProduct(string item)
		{
			return _db.Products.Where(x => x.ProductName.Contains(item)).Select(x => new ProductResponseModel
			{
				ProductName = x.ProductName,
				UnitPrice = x.UnitPrice,
				Amount = x.Amount,
			}).ToList();
		}

		//Burada mevcut Stok takip edebiliriz..
		public void Remainder(ProductResponseModel item, OrderDetail od)
		{
			Product p = _db.Products.FirstOrDefault(x => x.ID == item.ID);
			if (p == null)
			{
				throw new InvalidOperationException("Ürün Bulunamadı ");
			}

			if (p.Amount - od.Quantity < 0)
			{
				throw new InvalidOperationException("Stok Seviyesi Yetersiz");
			}
			p.Amount -= od.Quantity;
			_db.SaveChanges();
		}
	}
}
