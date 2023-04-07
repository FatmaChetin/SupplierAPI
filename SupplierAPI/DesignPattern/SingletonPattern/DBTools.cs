using SupplierAPI.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplierAPI.DesignPattern.SingletonPattern
{
    public class DBTools
    {
        DBTools()   { }
        static MyContext _dbInstance;
        public static MyContext DbInstance 
        {
            get 
            {
            if (_dbInstance == null) _dbInstance = new MyContext();
            return _dbInstance;
            }
        }
    }
}