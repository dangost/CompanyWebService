using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Controllers;
using WebService.Models;
using System.Web.Http;

namespace WebService.UnitTests
{ 
    [TestClass]
    public class PeopleControllTests
    {
        [TestMethod]
        public void Post()
        {
            // Arrange                  
            bool res = true;
            SQLiteServiceBase db = new SQLiteServiceBase();
            Person obj = GetValidObject();

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
            Person obj = GetValidObject();

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
            Person obj = GetValidObject();     

            // Act
            try
            {
                int len = 0;
                if (db.GetPeople() != null)
                {
                    foreach (var c in db.GetPeople())
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
            Person obj = GetInvalidObject();

            // Act
            try
            {
                int len = 0;
                if (db.GetPeople() != null)
                {
                    foreach (var c in db.GetPeople())
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

        Person GetValidObject()
        {
            Person obj = new Person();

            obj.FirstName = "Oleg";
            obj.LastName = "Olegivi4";
            obj.MiddleName = "OlehHHH";
            obj.Nickname = "Alexa";
            obj.CultureCode = 22999;
            obj.Gender = "female";

            return obj;
        }

        Person GetInvalidObject()
        {
            Person obj = new Person();

            obj.MiddleName = "OlehHHH";
            obj.Nickname = "Alexa";
            obj.CultureCode = 22999;

            return obj;
        }

    }
}

    