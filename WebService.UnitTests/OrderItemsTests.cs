using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Controllers;
using WebService.Models;
using System.Web.Http;

namespace WebService.UnitTests
{ 
    [TestClass]
    public class OrderItemsControllTests
    {
        [TestMethod]
        public void Post()
        {
            // Arrange                  
            bool res = true;
            SQLiteServiceBase db = new SQLiteServiceBase();
            OrderItem obj = GetValidObject();

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
            OrderItem obj = GetInvalidObject();

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
            OrderItem obj = GetValidObject();     

            // Act
            try
            {
                int len = 0;
                if (db.GetOrderItems() != null)
                {
                    foreach (var c in db.GetOrderItems())
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
            OrderItem obj = GetInvalidObject();

            // Act
            try
            {
                int len = 0;
                if (db.GetOrderItems() != null)
                {
                    foreach (var c in db.GetOrderItems())
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

        OrderItem GetValidObject()
        {
            OrderItem obj = new OrderItem();

            obj.OrderItemId = 1;
            obj.OrderId = 12;
            obj.ProductId = 123;
            obj.UnitPrice = 22.22d;
            obj.Quantity = 123.123d;
            return obj;
        }

        OrderItem GetInvalidObject()
        {
            OrderItem obj = new OrderItem();

            obj.UnitPrice = 22.2d;

            return obj;
        }

    }
}

    