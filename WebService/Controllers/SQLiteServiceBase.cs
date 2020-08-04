using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using WebService.Models;
using System.Web.Http;
using Dapper;

namespace WebService.Controllers
{
    public class SQLiteServiceBase : ApiController
    {
        public SQLiteServiceBase()
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

        ApplicationContext dataBase { get; set; }

        string sqLitePath = @"db\company.db";

        void Load()
        {
            File.Delete(sqLitePath);

            if(!File.Exists(sqLitePath))
            {
                if(!Directory.Exists(@"db"))
                {
                    Directory.CreateDirectory(@"db");
                }

                SQLiteConnection.CreateFile(sqLitePath);

                using (SQLiteConnection connection = new SQLiteConnection())
                {
                    connection.ConnectionString = "Data Source = " + sqLitePath;
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string personBase = @"CREATE TABLE [People] (
                    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [FirstName] TEXT NOT NULL,
                    [LastName] TEXT NOT NULL,
                    [MiddleName] TEXT NOT NULL,
                    [Nickname] TEXT NOT NULL,
                    [NatLangCode] INTEGER NOT NULL,
                    [CultureCode] INTEGER NOT NULL,
                    [Gender] TEXT NOT NULL
                    );";
                        command.CommandText = personBase;
                        command.CommandType = System.Data.CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }                
            }

            dataBase = new ApplicationContext();
            dataBase.People.Load();

            Update();
        }

        [HttpPost]
        void Add([FromBody]Person obj)
        {
            dataBase.People.Add(obj);
            Update();
        }

        [HttpPut]
        public void EditPerson(int id, [FromBody]Person obj)
        {
            if (id == obj.Id)
            {
                dataBase.Entry(obj).State = EntityState.Modified;

                dataBase.SaveChanges();
            }
        }

        void Delete(int id)
        {
            Person person = dataBase.People.Find(id);
            if (person != null)
            {
                dataBase.People.Remove(person);
                Update();
            }            
        }

        IEnumerable<Person> GetPeople()
        {
            return dataBase.People;
        }

        Person GetPersonId(int id)
        {
            Person person = new Person();

            foreach(Person p in dataBase.People)
            {
                if (p.Id == id)
                {
                    person = p;
                    break;
                }                
            }
            return person;
        }

        void Update()
        {
            dataBase.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dataBase.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}