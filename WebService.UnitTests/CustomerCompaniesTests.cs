using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Controllers;
using WebService.Models;
using System.Web.Http;

namespace WebService.UnitTests
{ 
    [TestClass]
    public class CustomerCompaniesControllTests
    {
        [TestMethod]
        public void Post()
        {
            // Arrange                  
            bool res = true;
            SQLiteServiceBase db = new SQLiteServiceBase();
            CustomerCompany obj = GetValidObject();

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
            CustomerCompany obj = GetValidObject();

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
            CustomerCompany obj = GetValidObject();     

            // Act
            try
            {
                int len = 0;
                if (db.GetCustomerCompanies() != null)
                {
                    foreach (var c in db.GetCustomerCompanies())
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
            CustomerCompany obj = GetInvalidObject();

            // Act
            try
            {
                int len = 0;
                if (db.GetCustomerCompanies() != null)
                {
                    foreach (var c in db.GetCustomerCompanies())
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

        CustomerCompany GetValidObject()
        {
            CustomerCompany obj = new CustomerCompany();

            obj.CompanyName = "fafafa";
            obj.CreditLimitCurrency = "dolls";
            obj.CompanyCreditLimit = 100000000;

            return obj;
        }

        CustomerCompany GetInvalidObject()
        {
            CustomerCompany obj = new CustomerCompany();

            obj.CompanyName = "";
            obj.CreditLimitCurrency = "";
            obj.CompanyCreditLimit = 100000000;

            return obj;
        }

    }
}

    