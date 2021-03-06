﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Controllers;
using WebService.Models;
using System.Web.Http;

namespace WebService.UnitTests
{ 
    [TestClass]
    public class CountriesControllTests
    {
        [TestMethod]
        public void Post()
        {
            // Arrange                  
            bool res = true;
            SQLiteServiceBase db = new SQLiteServiceBase();
            Country obj = GetValidObject();

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
            Country obj = GetValidObject();

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
            Country obj = GetValidObject();     

            // Act
            try
            {
                int len = 0;
                if (db.GetCountries() != null)
                {
                    foreach (var c in db.GetCountries())
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
            Country obj = GetInvalidObject();

            // Act
            try
            {
                int len = 0;
                if (db.GetCountries() != null)
                {
                    foreach (var c in db.GetCountries())
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

        Country GetValidObject()
        {
            Country country = new Country();
            country.CountryId = 0;
            country.CountryName = "Vilka";
            country.CountryCode = "fafa";
            country.CurrencyCode = "euro";
            country.NatLangCode = 228;

            return country;
        }

        Country GetInvalidObject()
        {
            Country country = new Country();
            country.CountryId = 0;
            country.CountryName = "";
            country.CountryCode = "";
            country.CurrencyCode = "euro";
            country.NatLangCode = 228;

            return country;
        }

    }
}
