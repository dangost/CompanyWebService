using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class PeopleRepository : IPeopleRepository
    {
        public PeopleRepository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<Person> People { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            //Create DataBase();

            dataBase = new ApplicationContext();

            dataBase.People.Load();

            Update();
        }

        public void Add(Person obj) 
        { 
            dataBase.People.Add(obj);
            Update(); 
        }

        public void Edit(int id, Person obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.People.FirstOrDefault(_ => _.Id == id);
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

        public void DeletePerson(int id) 
        { 
            Person obj = dataBase.People.Find(id); 
            if (obj != null) 
            { 
                dataBase.People.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<Person> GetPeople()
        { 
            return dataBase.People; 
        }

        public Person GetPeopleId(int id)
        { 
            Person obj = null; 
            foreach (Person o in dataBase.People) 
            { 
                if (o.Id == id) 
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
