using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        public OrderItemsRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<OrderItem> OrderItems { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            //Create DataBase();

            dataBase = new ApplicationContext();

            dataBase.OrderItems.Load();

            Update();
        }

        public void Add(OrderItem obj) 
        { 
            dataBase.OrderItems.Add(obj);
            Update(); 
        }

        public void Edit(int id, OrderItem obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.OrderItems.FirstOrDefault(_ => _.OrderItemId == id);
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

        public void DeleteOrderItem(int id) 
        { 
            OrderItem obj = dataBase.OrderItems.Find(id); 
            if (obj != null) 
            { 
                dataBase.OrderItems.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<OrderItem> GetOrderItems()
        { 
            return dataBase.OrderItems; 
        }

        public OrderItem GetOrderItemsId(int id)
        { 
            OrderItem obj = null; 
            foreach (OrderItem o in dataBase.OrderItems) 
            { 
                if (o.OrderItemId == id) 
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
