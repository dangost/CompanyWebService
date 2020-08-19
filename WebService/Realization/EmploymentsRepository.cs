using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class EmploymentsRepository : IEmploymentsRepository
    {
        public EmploymentsRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<Employment> Employments { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            SQLiteRepository.Initialize();

            dataBase = new ApplicationContext();

            dataBase.Employments.Load();

            Update();
        }

        public void Add(Employment obj) 
        { 
            dataBase.Employments.Add(obj);
            Update(); 
        }

        public void Edit(int id, Employment obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Employments.FirstOrDefault(_ => _.EmployeeId == id);
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

        public void DeleteEmployment(int id) 
        { 
            Employment obj = dataBase.Employments.Find(id); 
            if (obj != null) 
            { 
                dataBase.Employments.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<Employment> GetEmployments()
        { 
            return dataBase.Employments; 
        }

        public Employment GetEmploymentId(int id)
        { 
            Employment obj = null; 
            foreach (Employment o in dataBase.Employments) 
            { 
                if (o.EmployeeId == id) 
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
