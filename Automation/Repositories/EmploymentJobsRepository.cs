using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class EmploymentJobsRepository : IEmploymentJobsRepository
    {
        public EmploymentJobsRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<EmploymentJobs> EmploymentJobs { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            SQLiteRepository.CreateBase();

            dataBase = new ApplicationContext();

            dataBase.EmploymentJobs.Load();

            Update();
        }

        public void Add(EmploymentJobs obj) 
        { 
            dataBase.EmploymentJobs.Add(obj);
            Update(); 
        }

        public void Edit(int id, EmploymentJobs obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.EmploymentJobs.FirstOrDefault(_ => _.HRJobId == id);
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

        public void DeleteEmploymentJobs(int id) 
        { 
            EmploymentJobs obj = dataBase.EmploymentJobs.Find(id); 
            if (obj != null) 
            { 
                dataBase.EmploymentJobs.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<EmploymentJobs> GetEmploymentJobs()
        { 
            return dataBase.EmploymentJobs; 
        }

        public EmploymentJobs GetEmploymentJobsId(int id)
        { 
            EmploymentJobs obj = null; 
            foreach (EmploymentJobs o in dataBase.EmploymentJobs) 
            { 
                if (o.HRJobId == id) 
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
