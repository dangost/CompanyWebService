using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class OrdersRepository : IOrdersRepository
    {
        public OrdersRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<Orders> Orders { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            SQLiteSupport.CreateBase();

            dataBase = new ApplicationContext();

            dataBase.Orders.Load();

            Update();
        }

        public void Add(Orders obj) 
        { 
            dataBase.Orders.Add(obj);
            Update(); 
        }

        public void Edit(int id, Orders obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Orders.FirstOrDefault(_ => _.OrderId == id);
                try
                {
                    if (temp != null)
                    {
                        temp.OrderDate = obj.OrderDate;
                        temp.OrderCode = obj.OrderCode;
                        temp.OrderStatus = obj.OrderStatus;
                        temp.OrderTotal = obj.OrderTotal;
                        temp.OrderCurrency = obj.OrderCurrency;
                        temp.PromotionCode = obj.PromotionCode;

                        context.SaveChanges();
                    }
                }
                catch (Exception) { /*TO DO*/ }
            }
        }

        public void DeleteOrders(int id) 
        { 
            Orders obj = dataBase.Orders.Find(id); 
            if (obj != null) 
            { 
                dataBase.Orders.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<Orders> GetOrders()
        { 
            return dataBase.Orders; 
        }

        public Orders GetOrdersId(int id)
        { 
            Orders obj = null; 
            foreach (Orders o in dataBase.Orders) 
            { 
                if (o.OrderId == id) 
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
