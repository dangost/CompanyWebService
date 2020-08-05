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
            
            public DbSet<Country> Countries { get; set; }
            public DbSet<Customer> Customers { get; set; }
            public DbSet<CustomerCompany> CustomerCompanies { get; set; }
            public DbSet<CustomerEmployee> CustomerEmployees { get; set; }
            public DbSet<Employment> Employments { get; set; }
            public DbSet<EmploymentJobs> EmploymentJobs { get; set; }
            public DbSet<Inventory> Inventories { get; set; }
            public DbSet<Location> Locations { get; set; }
            public DbSet<OrderItem> OrderItems { get; set; }
            public DbSet<Orders> Orders { get; set; }
            public DbSet<Person> People { get; set; }
            public DbSet<PersonLocation> PersonLocations { get; set; }
            public DbSet<PhoneNumber> PhoneNumbers { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<RestrictedInfo> RestrictedInfo { get; set; }
            public DbSet<Warehouse> Warehouses { get; set; }
        }

        ApplicationContext dataBase { get; set; }

        string sqLitePath = @"D:\db\company.db";

        void Load()
        {  
            if(File.Exists(sqLitePath))
            {
                File.Delete(sqLitePath);
            }

            if(!File.Exists(sqLitePath))
            {
                if(!Directory.Exists(@"D:\db"))
                {
                    Directory.CreateDirectory(@"D:\db");
                }

                SQLiteConnection.CreateFile(sqLitePath);

                using (SQLiteConnection connection = new SQLiteConnection())
                {
                    connection.ConnectionString = "Data Source = " + sqLitePath;
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        string allTablesAutomated = @"CREATE TABLE [Country] (
	[CountryId]	INTEGER,
	[ContryName]	TEXT,
	[CountryCode]	TEXT,
	[NatLangCode]	INTEGER,
	[CurrencyCode]	TEXT,
	PRIMARY KEY([CountryId])
);

CREATE TABLE [Customer] (
	[CustomerId]	INTEGER,
	[PersonId]	INTEGER,
	[CustomerEmployeeId]	INTEGER,
	[AccountMgrId]	INTEGER,
	[IncomeLevel]	INTEGER,
	FOREIGN KEY([CustomerEmployeeId]) REFERENCES [CustomerEmployee]([CustomerEmployeeId]),
	FOREIGN KEY([PersonId]) REFERENCES [People]([Id]),
	FOREIGN KEY([CustomerId]) REFERENCES [Orders]([CustomerId])
);

CREATE TABLE [CustomerCompany] (
	[CompanyId]	INTEGER,
	[CompanyName]	TEXT,
	[CompanyCreditLimit]	INTEGER,
	[CredtLimitCurrency]	TEXT,
	PRIMARY KEY([CompanyId])
);


CREATE TABLE [CustomerCompany] (
	[CompanyId]	INTEGER,
	[CompanyName]	TEXT,
	[CompanyCreditLimit]	INTEGER,
	[CredtLimitCurrency]	TEXT,
	PRIMARY KEY([CompanyId])
);


CREATE TABLE [CustomerEmployee] (
	[CustomerEmployeeId]	INTEGER,
	[CompanyId]	INTEGER,
	[BadgeNumber]	TEXT,
	[JobTitle]	TEXT,
	[Department]	TEXT,
	[CreditLimit]	INTEGER,
	[CreditLimitCurrency]	TEXT,
	FOREIGN KEY([CompanyId]) REFERENCES [CustomerCompany]([CompanyId]),
	PRIMARY KEY([CustomerEmployeeId])
);


CREATE TABLE [Employment] (
	[EmployeeId]	INTEGER,
	[PersonId]	INTEGER,
	[HRjob]	INTEGER,
	[ManagerEmployeeId]	INTEGER,
	[StartDate]	TEXT,
	[EndDate]	TEXT,
	[CommissonPercent]	TEXT,
	[Employmentcol]	TEXT,
	PRIMARY KEY([EmployeeId]),
	FOREIGN KEY([HRjob]) REFERENCES [EmploymentJobs]([HRjobId]),
	FOREIGN KEY([PersonId]) REFERENCES [People]([Id])
);

CREATE TABLE [EmploymentJobs] (
	[HRjobId]	INTEGER,
	[CountriesCountryID]	INTEGER,
	[JobTitle]	TEXT,
	[MinSalary]	TEXT,
	[MaxSalary]	TEXT,
	PRIMARY KEY([HRjobId]),
	FOREIGN KEY([CountriesCountryID]) REFERENCES [Country]([CountryId])
);


CREATE TABLE [Inventory] (
	[InventoryId]	INTEGER,
	[ProductId]	INTEGER,
	[WarehouseId]	INTEGER,
	[QuantityOnHand]	INTEGER,
	[QuantityAvaliable]	INTEGER,
	FOREIGN KEY([ProductId]) REFERENCES [Product]([ProductId]),
	PRIMARY KEY([InventoryId])
);

CREATE TABLE [Location] (
	[LocationId]	INTEGER,
	[CountryId]	INTEGER,
	[AdressLine1]	TEXT,
	[AdressLine2]	TEXT,
	[City]	TEXT,
	[State]	TEXT,
	[District]	TEXT,
	[PostalCode]	TEXT,
	[LocationTypeCode]	INTEGER,
	[Description]	TEXT,
	[ShippingNotes]	TEXT,
	[CountriesCountryId]	INTEGER,
	FOREIGN KEY([CountriesCountryId]) REFERENCES [Country]([CountryId]),
	PRIMARY KEY([LocationId])
);


CREATE TABLE [OrderItem] (
	[OrderItemId]	INTEGER,
	[OrderId]	INTEGER,
	[ProductId]	INTEGER,
	[UnitPrice]	INTEGER,
	[Quantity]	INTEGER,
	PRIMARY KEY([OrderItemId]),
	FOREIGN KEY([ProductId]) REFERENCES [Product]([ProductId]),
	FOREIGN KEY([OrderId]) REFERENCES [Orders]([OrderId])
);

CREATE TABLE [Orders] (
	[OrderId]	INTEGER,
	[CustomerId]	INTEGER,
	[SalesRepId]	INTEGER,
	[OrderDate]	TEXT,
	[OrderCode]	TEXT,
	[OrderStatus]	TEXT,
	[OrderTotal]	INTEGER,
	[OrderCurrency]	TEXT,
	[PromotionCode]	TEXT,
	FOREIGN KEY([SalesRepId]) REFERENCES [CustomerCompany]([CompanyId]),
	PRIMARY KEY([OrderId],[CustomerId])
);


CREATE TABLE [People] (
                    [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [FirstName] TEXT NOT NULL,
                    [LastName] TEXT NOT NULL,
                    [MiddleName] TEXT NOT NULL,
                    [Nickname] TEXT NOT NULL,
                    [NatLangCode] INTEGER NOT NULL,
                    [CultureCode] INTEGER NOT NULL,
                    [Gender] TEXT NOT NULL
                    );



CREATE TABLE [PersonLocations] (
	[PersonsPersonId]	INTEGER,
	[LocationsLocationId]	INTEGER,
	[SubAdress]	TEXT,
	[LocationUsage]	TEXT,
	[Notes]	TEXT,
	FOREIGN KEY([PersonsPersonId]) REFERENCES [People]([Id]),
	FOREIGN KEY([LocationsLocationId]) REFERENCES [Location]([LocationId])
);


CREATE TABLE [PhoneNumber] (
	[PhoneNumberId]	INTEGER,
	[PeoplePersonId]	INTEGER,
	[LocationsLocationId]	INTEGER,
	[PhoneNumber]	INTEGER,
	[CountryCode]	INTEGER,
	[PhoneType]	INTEGER,
	FOREIGN KEY([PeoplePersonId]) REFERENCES [People]([Id]),
	FOREIGN KEY([LocationsLocationId]) REFERENCES [Location]([LocationId]),
	PRIMARY KEY([PhoneNumberId])
);


CREATE TABLE [Product] (
	[ProductId]	INTEGER,
	[ProductName]	TEXT,
	[Description]	TEXT,
	[Category]	INTEGER,
	[WeightClass]	INTEGER,
	[WarrantlyPeriod]	INTEGER,
	[SupplierId]	INTEGER,
	[Status]	TEXT,
	[ListPrice]	INTEGER,
	[MinimumPrice]	INTEGER,
	[PriceCurrency]	TEXT,
	[CatalogURL]	TEXT,
	PRIMARY KEY([ProductId])
);


CREATE TABLE [RestrictedInfo] (
	[PersonId]	INTEGER,
	[DateOfBirth]	TEXT,
	[DateOfDeath]	TEXT,
	[GovermentId]	TEXT,
	[PassportId]	TEXT,
	[HireDate]	TEXT,
	[SeniorityCode]	INTEGER,
	FOREIGN KEY([PersonId]) REFERENCES [People]([Id])
);


CREATE TABLE [Warehouse] (
	[WarehouseId]	INTEGER,
	[LocationId]	INTEGER,
	[WarehouseName]	TEXT,
	FOREIGN KEY([WarehouseId]) REFERENCES [Inventory]([WarehouseId]),
	FOREIGN KEY([LocationId]) REFERENCES [Location]([LocationId])
); ";  
                        command.CommandText = allTablesAutomated;
                        command.CommandType = System.Data.CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }                
            }

            dataBase = new ApplicationContext();
            dataBase.People.Load();
            dataBase.Countries.Load();
            dataBase.Customers.Load();
            dataBase.CustomerCompanies.Load();
            dataBase.CustomerEmployees.Load();
            dataBase.Employments.Load();
            dataBase.EmploymentJobs.Load();
            dataBase.Inventories.Load();
            dataBase.Locations.Load();
            dataBase.OrderItems.Load();
            dataBase.Orders.Load();
            dataBase.PersonLocations.Load();
            dataBase.PhoneNumbers.Load();
            dataBase.Products.Load();
            dataBase.RestrictedInfo.Load();
            dataBase.Warehouses.Load();

            Update();
        }

        [HttpPost]
        public void Add([FromBody]Person obj)
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

                Update();
            }
        }

        public void Delete(int id)
        {
            Person person = dataBase.People.Find(id);
            if (person != null)
            {
                dataBase.People.Remove(person);
                Update();
            }            
        }

        public IEnumerable<Person> GetPeople()
        {
            return dataBase.People;
        }

        public Person GetPersonId(int id)
        {
            Person person = null;

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