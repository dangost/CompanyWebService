using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class CustomersRepository : ICustomersRepository
    {
        public CustomersRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<Customer> Customers { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            SQLiteRepository.Initialize();

            dataBase = new ApplicationContext();

            dataBase.Customers.Load();

            Update();
        }

        public void Add(Customer obj) 
        { 
            dataBase.Customers.Add(obj);
            Update(); 
        }

        public void Edit(int id, Customer obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Customers.FirstOrDefault(_ => _.CustomerId == id);
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

        public void DeleteCustomer(int id) 
        { 
            Customer obj = dataBase.Customers.Find(id); 
            if (obj != null) 
            { 
                dataBase.Customers.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<Customer> GetCustomers()
        { 
            return dataBase.Customers; 
        }

        public Customer GetCustomerId(int id)
        { 
            Customer obj = null; 
            foreach (Customer o in dataBase.Customers) 
            { 
                if (o.CustomerId == id) 
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
