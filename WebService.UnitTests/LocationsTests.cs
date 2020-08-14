using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Controllers;
using WebService.Models;
using System.Web.Http;

namespace WebService.UnitTests
{ 
    [TestClass]
    public class LocationsControllTests
    {
        [TestMethod]
        public void Post()
        {
            // Arrange                  
            bool res = true;
            SQLiteServiceBase db = new SQLiteServiceBase();
            Location obj = GetValidObject();

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
            Location obj = GetValidObject();

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
            Location obj = GetValidObject();     

            // Act
            try
            {
                int len = 0;
                if (db.GetLocations() != null)
                {
                    foreach (var c in db.GetLocations())
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
            Location obj = GetInvalidObject();

            // Act
            try
            {
                int len = 0;
                if (db.GetLocations() != null)
                {
                    foreach (var c in db.GetLocations())
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

        Location GetValidObject()
        {
            Location obj = new Location();

            obj.CountryId = 12;
            obj.AdressLine1 = "fafafa";
            obj.AdressLine2 = "jajaja";
            obj.City = "Minsk";
            obj.State = "California";
            obj.District = "memeonmeme";
            obj.PostalCode = "asdf";
            obj.LocationTypeCode = 444555;
            obj.Description = "Have a nice day!";
            obj.ShippingNotes = "Do not break nothing";
            obj.CountriesCountryId = 44;

            return obj;
        }

        Location GetInvalidObject()
        {
            Location obj = new Location();

            obj.AdressLine1 = "fafafa";
            obj.AdressLine2 = "jajaja";

            return obj;
        }

    }
}

    