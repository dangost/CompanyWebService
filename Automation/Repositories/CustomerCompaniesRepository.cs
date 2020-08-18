using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class CustomerCompaniesRepository : ICustomerCompaniesRepository
    {
        public CustomerCompaniesRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<CustomerCompany> CustomerCompanies { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            //Create DataBase();

            dataBase = new ApplicationContext();

            dataBase.CustomerCompanies.Load();

            Update();
        }

        public void Add(CustomerCompany obj) 
        { 
            dataBase.CustomerCompanies.Add(obj);
            Update(); 
        }

        public void Edit(int id, CustomerCompany obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.CustomerCompanies.FirstOrDefault(_ => _.CompanyId == id);
                try
                {
                    if (temp != null)
                    {
                        //
                        //  change properties
                        //

                        context.SaveChanges();
                    }
                }
                catch (Exception) { /*TO DO*/ }
            }
        }

        public void DeleteCustomerCompany(int id) 
        { 
            CustomerCompany obj = dataBase.CustomerCompanies.Find(id); 
            if (obj != null) 
            { 
                dataBase.CustomerCompanies.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<CustomerCompany> GetCustomerCompanies()
        { 
            return dataBase.CustomerCompanies; 
        }

        public CustomerCompany GetCustomerCompaniesId(int id)
        { 
            CustomerCompany obj = null; 
            foreach (CustomerCompany o in dataBase.CustomerCompanies) 
            { 
                if (o.CompanyId == id) 
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
