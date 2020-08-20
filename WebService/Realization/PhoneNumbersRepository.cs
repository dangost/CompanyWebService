using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class PhoneNumbersRepository : IPhoneNumbersRepository
    {
        public PhoneNumbersRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            SQLiteRepository.Initialize();

            dataBase = new ApplicationContext();

            dataBase.PhoneNumbers.Load();

            Update();
        }

        public void Add(PhoneNumber obj) 
        { 
            dataBase.PhoneNumbers.Add(obj);
            Update(); 
        }

        public void Edit(int id, PhoneNumber obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.PhoneNumbers.FirstOrDefault(_ => _.PhoneNumberId == id);
                try
                {
                    if (temp != null)
                    {
                        temp.Phonenumber = obj.Phonenumber;
                        temp.CountryCode = obj.CountryCode;
                        temp.PhoneType = obj.PhoneType;

                        context.SaveChanges();
                    }
                }
                catch (Exception) { /*TO DO*/ }
            }
        }

        public void DeletePhoneNumber(int id) 
        { 
            PhoneNumber obj = dataBase.PhoneNumbers.Find(id); 
            if (obj != null) 
            { 
                dataBase.PhoneNumbers.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<PhoneNumber> GetPhoneNumbers()
        { 
            return dataBase.PhoneNumbers; 
        }

        public PhoneNumber GetPhoneNumberId(int id)
        { 
            PhoneNumber obj = null; 
            foreach (PhoneNumber o in dataBase.PhoneNumbers) 
            { 
                if (o.PhoneNumberId == id) 
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
