using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class ProductsRepository : IProductsRepository
    {
        public ProductsRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<Product> Products { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            SQLiteRepository.Initialize();

            dataBase = new ApplicationContext();

            dataBase.Products.Load();

            Update();
        }

        public void Add(Product obj) 
        { 
            dataBase.Products.Add(obj);
            Update(); 
        }

        public void Edit(int id, Product obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Products.FirstOrDefault(_ => _.ProductId == id);
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

        public void DeleteProduct(int id) 
        { 
            Product obj = dataBase.Products.Find(id); 
            if (obj != null) 
            { 
                dataBase.Products.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<Product> GetProducts()
        { 
            return dataBase.Products; 
        }

        public Product GetProductId(int id)
        { 
            Product obj = null; 
            foreach (Product o in dataBase.Products) 
            { 
                if (o.ProductId == id) 
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
