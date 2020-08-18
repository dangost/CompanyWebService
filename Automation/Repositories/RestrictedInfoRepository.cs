using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class RestrictedInfoRepository : IRestrictedInfoRepository
    {
        public RestrictedInfoRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<RestrictedInfo> RestrictedInfo { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            SQLiteSupport.CreateBase();

            dataBase = new ApplicationContext();

            dataBase.RestrictedInfo.Load();

            Update();
        }

        public void Add(RestrictedInfo obj) 
        { 
            dataBase.RestrictedInfo.Add(obj);
            Update(); 
        }

        public void Edit(int id, RestrictedInfo obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.RestrictedInfo.FirstOrDefault(_ => _. == id);
                try
                {
                    if (temp != null)
                    {
                        temp.DateOfBirth = obj.DateOfBirth;
                        temp.DateOfDeath = obj.DateOfDeath;
                        temp.GovernmentId = obj.GovernmentId;
                        temp.PassportId = obj.PassportId;
                        temp.HireDire = obj.HireDire;
                        temp.SeniorityCode = obj.SeniorityCode;

                        context.SaveChanges();
                    }
                }
                catch (Exception) { /*TO DO*/ }
            }
        }

        public void DeleteRestrictedInfo(int id) 
        { 
            RestrictedInfo obj = dataBase.RestrictedInfo.Find(id); 
            if (obj != null) 
            { 
                dataBase.RestrictedInfo.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<RestrictedInfo> GetRestrictedInfo()
        { 
            return dataBase.RestrictedInfo; 
        }

        public RestrictedInfo GetRestrictedInfoId(int id)
        { 
            RestrictedInfo obj = null; 
            foreach (RestrictedInfo o in dataBase.RestrictedInfo) 
            { 
                if (o. == id) 
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
