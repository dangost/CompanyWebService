using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class CountriesRepository : ICountriesRepository
    {
        public CountriesRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<Country> Countries { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            SQLiteSupport.CreateBase();

            dataBase = new ApplicationContext();

            dataBase.Countries.Load();

            Update();
        }

        public void Add(Country obj) 
        { 
            dataBase.Countries.Add(obj);
            Update(); 
        }

        public void Edit(int id, Country obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Countries.FirstOrDefault(_ => _.CountryId == id);
                try
                {
                    if (temp != null)
                    {
                        temp.CountryName = obj.CountryName;
                        temp.CountryCode = obj.CountryCode;
                        temp.NatLangCode = obj.NatLangCode;
                        temp.CurrencyCode = obj.CurrencyCode;

                        context.SaveChanges();
                    }
                }
                catch (Exception) { /*TO DO*/ }
            }
        }

        public void DeleteCountry(int id) 
        { 
            Country obj = dataBase.Countries.Find(id); 
            if (obj != null) 
            { 
                dataBase.Countries.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<Country> GetCountries()
        { 
            return dataBase.Countries; 
        }

        public Country GetCountriesId(int id)
        { 
            Country obj = null; 
            foreach (Country o in dataBase.Countries) 
            { 
                if (o.CountryId == id) 
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
