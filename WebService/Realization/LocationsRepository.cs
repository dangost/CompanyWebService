using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class LocationsRepository : ILocationsRepository
    {
        public LocationsRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<Location> Locations { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            SQLiteRepository.Initialize();

            dataBase = new ApplicationContext();

            dataBase.Locations.Load();

            Update();
        }

        public void Add(Location obj) 
        { 
            dataBase.Locations.Add(obj);
            Update(); 
        }

        public void Edit(int id, Location obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Locations.FirstOrDefault(_ => _.LocationId == id);
                try
                {
                    if (temp != null)
                    {
                        temp.CountryId = obj.CountryId;
                        temp.AdressLine1 = obj.AdressLine1;
                        temp.AdressLine2 = obj.AdressLine2;
                        temp.City = obj.City;
                        temp.State = obj.State;
                        temp.District = obj.District;
                        temp.PostalCode = obj.PostalCode;
                        temp.Description = obj.Description;
                        temp.LocationTypeCode = obj.LocationTypeCode;
                        temp.ShippingNotes = obj.ShippingNotes;


                        context.SaveChanges();
                    }
                }
                catch (Exception) { /*TO DO*/ }
            }
        }

        public void DeleteLocation(int id) 
        { 
            Location obj = dataBase.Locations.Find(id); 
            if (obj != null) 
            { 
                dataBase.Locations.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<Location> GetLocations()
        { 
            return dataBase.Locations; 
        }

        public Location GetLocationId(int id)
        { 
            Location obj = null; 
            foreach (Location o in dataBase.Locations) 
            { 
                if (o.LocationId == id) 
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
