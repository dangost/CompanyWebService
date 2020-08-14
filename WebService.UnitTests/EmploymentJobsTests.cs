using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Controllers;
using WebService.Models;
using System.Web.Http;

namespace WebService.UnitTests
{ 
    [TestClass]
    public class EmploymentJobsControllTests
    {
        [TestMethod]
        public void Post()
        {
            // Arrange                  
            bool res = true;
            SQLiteServiceBase db = new SQLiteServiceBase();
            EmploymentJobs obj = GetValidObject();

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
            EmploymentJobs obj = GetValidObject();

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
            EmploymentJobs obj = GetValidObject();     

            // Act
            try
            {
                int len = 0;
                if (db.GetEmploymentJobs() != null)
                {
                    foreach (var c in db.GetEmploymentJobs())
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
            EmploymentJobs obj = GetInvalidObject();

            // Act
            try
            {
                int len = 0;
                if (db.GetEmploymentJobs() != null)
                {
                    foreach (var c in db.GetEmploymentJobs())
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

        EmploymentJobs GetValidObject()
        {
            EmploymentJobs obj = new EmploymentJobs();

            obj.JobTitle = "God";
            obj.MinSalary = 1;
            obj.MaxSalary = 2;

            return obj;
        }

        EmploymentJobs GetInvalidObject()
        {
            EmploymentJobs obj = new EmploymentJobs();

            obj.JobTitle = "";
            return obj;
        }

    }
}

    