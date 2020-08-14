using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Controllers;
using WebService.Models;
using System.Web.Http;

namespace WebService.UnitTests
{ 
    [TestClass]
    public class ProductsControllTests
    {
        [TestMethod]
        public void Post()
        {
            // Arrange                  
            bool res = true;
            SQLiteServiceBase db = new SQLiteServiceBase();
            Product obj = GetValidObject();

            // Act
            try
            {
                db.Add(obj);
            }
            catch (Exception)
            {
                res = false;
            }

            // Assert            
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void InvalidPost()
        {
            // Arrange                  
            bool res = false;
            SQLiteServiceBase db = new SQLiteServiceBase();
            Product obj = GetValidObject();

            // Act
            try
            {
                db.Add(obj);
            }
            catch (Exception)
            {
                res = true;
            }

            // Assert            
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void Put()
        {
            // Arrange                  
            bool res = true;
            SQLiteServiceBase db = new SQLiteServiceBase();
            Product obj = GetValidObject();     

            // Act
            try
            {
                int len = 0;
                if (db.GetProducts() != null)
                {
                    foreach (var c in db.GetProducts())
                    {
                        len++;
                    }
                }
                if (len != 0)
                {
                    db.Edit(len - 1, obj);
                }

                
            }
            catch (Exception)
            {
                res = false;
            }

            // Assert            
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void InvalidPut()
        {
            // Arrange                  
            bool res = false;
            SQLiteServiceBase db = new SQLiteServiceBase();
            Product obj = GetInvalidObject();

            // Act
            try
            {
                int len = 0;
                if (db.GetProducts() != null)
                {
                    foreach (var c in db.GetProducts())
                    {
                        len++;
                    }
                }
                if (len != 0)
                {
                    db.Edit(len - 1, obj);
                }
            }
            catch (Exception)
            {
                res = true;
            }

            // Assert            
            Assert.IsFalse(res);
        }

        Product GetValidObject()
        {
            Product obj = new Product();

            obj.ProductName = "Milk";
            obj.Description = "From alive cow";
            obj.Category = 003;
            obj.WeightClass = 900;
            obj.WarrantlyPeriod = 3;
            obj.SupplierId = 123;
            obj.Status = "Looking good";
            obj.ListPrice = 150;
            obj.MinimumPrice = 11;
            obj.PriceCurrency = "BYN";
            obj.CatalogURL = @"https:\\myrealshop.com\milkfromrealcow";

            return obj;
        }

        Product GetInvalidObject()
        {
            Product obj = new Product();

            obj.MinimumPrice = 11;
            obj.PriceCurrency = "BYN";

            return obj;
        }

    }
}

    