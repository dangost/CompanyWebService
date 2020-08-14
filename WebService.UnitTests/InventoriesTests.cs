using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Controllers;
using WebService.Models;
using System.Web.Http;

namespace WebService.UnitTests
{ 
    [TestClass]
    public class InventoriesControllTests
    {
        [TestMethod]
        public void Post()
        {
            // Arrange                  
            bool res = true;
            SQLiteServiceBase db = new SQLiteServiceBase();
            Inventory obj = GetValidObject();

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
            Inventory obj = GetValidObject();

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
            Inventory obj = GetValidObject();     

            // Act
            try
            {
                int len = 0;
                if (db.GetInventories() != null)
                {
                    foreach (var c in db.GetInventories())
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
            Inventory obj = GetInvalidObject();

            // Act
            try
            {
                int len = 0;
                if (db.GetInventories() != null)
                {
                    foreach (var c in db.GetInventories())
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

        Inventory GetValidObject()
        {
            Inventory obj = new Inventory();

            obj.WarehouseId = 111;
            obj.QuantityAvaliable = 123;
            obj.QuantityOnHand = 333;

            return obj;
        }

        Inventory GetInvalidObject()
        {
            Inventory obj = new Inventory();

            obj.WarehouseId = -1;

            return obj;
        }

    }
}

    