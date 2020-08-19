using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class InventoriesRepository : IInventoriesRepository
    {
        public InventoriesRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<Inventory> Inventories { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            SQLiteRepository.Initialize();

            dataBase = new ApplicationContext();

            dataBase.Inventories.Load();

            Update();
        }

        public void Add(Inventory obj) 
        { 
            dataBase.Inventories.Add(obj);
            Update(); 
        }

        public void Edit(int id, Inventory obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Inventories.FirstOrDefault(_ => _.InventoryId == id);
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

        public void DeleteInventory(int id) 
        { 
            Inventory obj = dataBase.Inventories.Find(id); 
            if (obj != null) 
            { 
                dataBase.Inventories.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<Inventory> GetInventories()
        { 
            return dataBase.Inventories; 
        }

        public Inventory GetInventoryId(int id)
        { 
            Inventory obj = null; 
            foreach (Inventory o in dataBase.Inventories) 
            { 
                if (o.InventoryId == id) 
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
