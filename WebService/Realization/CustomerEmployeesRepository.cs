using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class CustomerEmployeesRepository : ICustomerEmployeesRepository
    {
        public CustomerEmployeesRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<CustomerEmployee> CustomerEmployees { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            SQLiteRepository.Initialize();

            dataBase = new ApplicationContext();

            dataBase.CustomerEmployees.Load();

            Update();
        }

        public void Add(CustomerEmployee obj) 
        { 
            dataBase.CustomerEmployees.Add(obj);
            Update(); 
        }

        public void Edit(int id, CustomerEmployee obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.CustomerEmployees.FirstOrDefault(_ => _.CustomerEmployeeId == id);
                try
                {
                    if (temp != null)
                    {
                        temp.BadgeNumber = obj.BadgeNumber;
                        temp.JobTitle = obj.JobTitle;
                        temp.Department = obj.Department;
                        temp.CreditLimit = obj.CreditLimit;
                        temp.CreditLimitCurrency = obj.CreditLimitCurrency;


                        context.SaveChanges();
                    }
                }
                catch (Exception) { /*TO DO*/ }
            }
        }

        public void DeleteCustomerEmployee(int id) 
        { 
            CustomerEmployee obj = dataBase.CustomerEmployees.Find(id); 
            if (obj != null) 
            { 
                dataBase.CustomerEmployees.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<CustomerEmployee> GetCustomerEmployees()
        { 
            return dataBase.CustomerEmployees; 
        }

        public CustomerEmployee GetCustomerEmployeeId(int id)
        { 
            CustomerEmployee obj = null; 
            foreach (CustomerEmployee o in dataBase.CustomerEmployees) 
            { 
                if (o.CustomerEmployeeId == id) 
                { 
                    obj = o; break; 
                } 
            } return obj;
        }

        public void Update()
        {
            dataBase.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dataBase != null)
                {
                    dataBase.Dispose();
                    dataBase = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
