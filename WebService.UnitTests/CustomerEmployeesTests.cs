using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Controllers;
using WebService.Models;
using System.Web.Http;

namespace WebService.UnitTests
{ 
    [TestClass]
    public class CustomerEmployeesControllTests
    {
        [TestMethod]
        public void Post()
        {
            // Arrange                  
            bool res = true;
            SQLiteServiceBase db = new SQLiteServiceBase();
            CustomerEmployee obj = GetValidObject();

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
            CustomerEmployee obj = GetValidObject();

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
            CustomerEmployee obj = GetValidObject();     

            // Act
            try
            {
                int len = 0;
                if (db.GetCustomerEmployees() != null)
                {
                    foreach (var c in db.GetCustomerEmployees())
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
            CustomerEmployee obj = GetInvalidObject();

            // Act
            try
            {
                int len = 0;
                if (db.GetCustomerEmployees() != null)
                {
                    foreach (var c in db.GetCustomerEmployees())
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

        CustomerEmployee GetValidObject()
        {
            CustomerEmployee obj = new CustomerEmployee();

            obj.BadgeNumber = "asd123";
            obj.JobTitle = "Programmer";
            obj.Department = "IT";
            obj.CreditLimit = 10000;
            obj.CreditLimitCurrency = "uhanies";

            return obj;
        }

        CustomerEmployee GetInvalidObject()
        {
            CustomerEmployee obj = new CustomerEmployee();

            obj.BadgeNumber = "";
            obj.JobTitle = "Micro4el";
            obj.Department = "";
            obj.CreditLimit = 100000000;
            obj.CreditLimitCurrency = "euro";

            return obj;
        }

    }
}

    