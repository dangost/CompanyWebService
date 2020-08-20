using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class PersonLocationsRepository : IPersonLocationsRepository
    {
        public PersonLocationsRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<PersonLocation> PersonLocations { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            SQLiteRepository.Initialize();

            dataBase = new ApplicationContext();

            dataBase.PersonLocations.Load();

            Update();
        }

        public void Add(PersonLocation obj) 
        { 
            dataBase.PersonLocations.Add(obj);
            Update(); 
        }

        public void Edit(int id, PersonLocation obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.PersonLocations.FirstOrDefault(_ => _.LocationsLocationId == id);
                try
                {
                    if (temp != null)
                    {
                        temp.SubAdress = obj.SubAdress;
                        temp.LocationUsage = obj.LocationUsage;
                        temp.Notes = obj.Notes;

                        context.SaveChanges();
                    }
                }
                catch (Exception) { /*TO DO*/ }
            }
        }

        public void DeletePersonLocation(int id) 
        { 
            PersonLocation obj = dataBase.PersonLocations.Find(id); 
            if (obj != null) 
            { 
                dataBase.PersonLocations.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<PersonLocation> GetPersonLocations()
        { 
            return dataBase.PersonLocations; 
        }

        public PersonLocation GetPersonLocationId(int id)
        { 
            PersonLocation obj = null; 
            foreach (PersonLocation o in dataBase.PersonLocations) 
            { 
                if (o.LocationsLocationId == id) 
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
