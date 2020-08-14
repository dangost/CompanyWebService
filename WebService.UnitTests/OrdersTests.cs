using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Controllers;
using WebService.Models;
using System.Web.Http;

namespace WebService.UnitTests
{ 
    [TestClass]
    public class OrdersControllTests
    {
        [TestMethod]
        public void Post()
        {
            // Arrange                  
            bool res = true;
            SQLiteServiceBase db = new SQLiteServiceBase();
            Orders obj = GetValidObject();

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
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void InvalidPost()
        {
            // Arrange                  
            bool res = false;
            SQLiteServiceBase db = new SQLiteServiceBase();
            Orders obj = GetInvalidObject();

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
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Put()
        {
            // Arrange                  
            bool res = true;
            SQLiteServiceBase db = new SQLiteServiceBase();
            Orders obj = GetValidObject();     

            // Act
            try
            {
                int len = 0;
                if (db.GetOrders() != null)
                {
                    foreach (var c in db.GetOrders())
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
            Orders obj = GetInvalidObject();

            // Act
            try
            {
                int len = 0;
                if (db.GetOrders() != null)
                {
                    foreach (var c in db.GetOrders())
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

        Orders GetValidObject()
        {
            Orders obj = new Orders();

            obj.OrderId = 1;
            obj.CustomerId = 123;
            obj.SalesRepId = 123;
            obj.OrderDate = "today";
            obj.OrderCode = 228;
            obj.OrderStatus = "nice";
            obj.OrderTotal = 6000;
            obj.OrderCurrency = "dolls";
            obj.PromotionCode = "FFAAQQ";

            return obj;
        }

        Orders GetInvalidObject()
        {
            Orders obj = new Orders();

            obj.OrderTotal = 6000;
            obj.OrderCurrency = "dolls";

            return obj;
        }

    }
}

    