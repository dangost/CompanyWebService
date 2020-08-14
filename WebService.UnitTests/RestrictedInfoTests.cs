using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Controllers;
using WebService.Models;
using System.Web.Http;

namespace WebService.UnitTests
{ 
    [TestClass]
    public class RestrictedInfoControllTests
    {
        [TestMethod]
        public void Post()
        {
            // Arrange                  
            bool res = true;
            SQLiteServiceBase db = new SQLiteServiceBase();
            RestrictedInfo obj = GetValidObject();

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
            RestrictedInfo obj = GetInvalidObject();

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
            RestrictedInfo obj = GetValidObject();     

            // Act
            try
            {
                int len = 0;
                if (db.GetRestrictedInfo() != null)
                {
                    foreach (var c in db.GetRestrictedInfo())
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
            RestrictedInfo obj = GetInvalidObject();

            // Act
            try
            {
                int len = 0;
                if (db.GetRestrictedInfo() != null)
                {
                    foreach (var c in db.GetRestrictedInfo())
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

        RestrictedInfo GetValidObject()
        {
            RestrictedInfo obj = new RestrictedInfo();

            obj.DateOfBirth = "13.12.2001";
            obj.DateOfDeath = "unknown";
            obj.GovernmentId = "why Id is string?";
            obj.PassportId = "MP12333";
            obj.HireDire = "what is it";
            obj.SeniorityCode = 112233;

            return obj;
        }

        RestrictedInfo GetInvalidObject()
        {
            RestrictedInfo obj = new RestrictedInfo();

            obj.DateOfBirth = "13.12.2001";
            obj.DateOfDeath = "unknown";

            return obj;
        }

    }
}

    