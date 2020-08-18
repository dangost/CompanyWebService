using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class WarehousesRepository : IWarehousesRepository
    {
        public WarehousesRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<Warehouse> Warehouses { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            //Create DataBase();

            dataBase = new ApplicationContext();

            dataBase.Warehouses.Load();

            Update();
        }

        public void Add(Warehouse obj) 
        { 
            dataBase.Warehouses.Add(obj);
            Update(); 
        }

        public void Edit(int id, Warehouse obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Warehouses.FirstOrDefault(_ => _.WarehouseId == id);
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

        public void DeleteWarehouse(int id) 
        { 
            Warehouse obj = dataBase.Warehouses.Find(id); 
            if (obj != null) 
            { 
                dataBase.Warehouses.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<Warehouse> GetWarehouses()
        { 
            return dataBase.Warehouses; 
        }

        public Warehouse GetWarehousesId(int id)
        { 
            Warehouse obj = null; 
            foreach (Warehouse o in dataBase.Warehouses) 
            { 
                if (o.WarehouseId == id) 
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
