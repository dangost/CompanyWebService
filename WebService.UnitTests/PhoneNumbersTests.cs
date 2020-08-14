using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Controllers;
using WebService.Models;
using System.Web.Http;

namespace WebService.UnitTests
{ 
    [TestClass]
    public class PhoneNumbersControllTests
    {
        [TestMethod]
        public void Post()
        {
            // Arrange                  
            bool res = true;
            SQLiteServiceBase db = new SQLiteServiceBase();
            PhoneNumber obj = GetValidObject();

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
            PhoneNumber obj = GetValidObject();

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
            PhoneNumber obj = GetValidObject();     

            // Act
            try
            {
                int len = 0;
                if (db.GetPhoneNumbers() != null)
                {
                    foreach (var c in db.GetPhoneNumbers())
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
            PhoneNumber obj = GetInvalidObject();

            // Act
            try
            {
                int len = 0;
                if (db.GetPhoneNumbers() != null)
                {
                    foreach (var c in db.GetPhoneNumbers())
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

        PhoneNumber GetValidObject()
        {
            PhoneNumber obj = new PhoneNumber();

            obj.Phonenumber = 7788;
            obj.CountryCode = 123;
            obj.PhoneType = 111;
            return obj;
        }

        PhoneNumber GetInvalidObject()
        {
            PhoneNumber obj = new PhoneNumber();

            obj.Phonenumber = 7788;

            return obj;
        }

    }
}

    