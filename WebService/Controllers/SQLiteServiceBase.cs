using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using WebService.Models;
using System.Web.Http;
using System;
using Dapper;

namespace WebService.Controllers
{
    public class SQLiteServiceBase : IRepository
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


        ApplicationContext dataBase;

        string sqLitePath = @"db\company.db";

        public void Load()
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
                        string allTablesAutomated = @"CREATE TABLE [Countries] (
	[CountryId]	INTEGER,
	[CountryName]	TEXT,
	[CountryCode]	TEXT,
	[NatLangCode]	INTEGER,
	[CurrencyCode]	TEXT,
	PRIMARY KEY([CountryId])
);

CREATE TABLE [Customers] (
	[CustomerId]	INTEGER,
	[PersonId]	INTEGER,
	[CustomerEmployeeId]	INTEGER,
	[AccountMgrId]	INTEGER,
	[IncomeLevel]	INTEGER,
	FOREIGN KEY([CustomerEmployeeId]) REFERENCES [CustomerEmployees]([CustomerEmployeeId]),
	FOREIGN KEY([PersonId]) REFERENCES [People]([Id]),
	FOREIGN KEY([CustomerId]) REFERENCES [Orders]([CustomerId]),
    PRIMARY KEY([CustomerId])
);

CREATE TABLE [CustomerCompanies] (
	[CompanyId]	INTEGER,
	[CompanyName]	TEXT,
	[CompanyCreditLimit]	INTEGER,
	[CreditLimitCurrency]	TEXT,
	PRIMARY KEY([CompanyId])
);

CREATE TABLE [CustomerEmployees] (
	[CustomerEmployeeId]	INTEGER,
	[CompanyId]	INTEGER,
	[BadgeNumber]	TEXT,
	[JobTitle]	TEXT,
	[Department]	TEXT,
	[CreditLimit]	INTEGER,
	[CreditLimitCurrency]	TEXT,
	FOREIGN KEY([CompanyId]) REFERENCES [CustomerCompanies]([CompanyId]),
	PRIMARY KEY([CustomerEmployeeId])
);


CREATE TABLE [Employments] (
	[EmployeeId]	INTEGER,
	[PersonId]	INTEGER,
	[HRJobId]	INTEGER,
	[ManagerEmployeeId]	INTEGER,
	[StartDate]	TEXT,
	[EndDate]	TEXT,
    [Salary]    INTEGER,
	[CommissionPercent]	INTEGER,
	[Employmentcol]	TEXT,
	PRIMARY KEY([EmployeeId]),
	FOREIGN KEY([HRJobId]) REFERENCES [EmploymentJobs]([HRJobId]),
	FOREIGN KEY([PersonId]) REFERENCES [People]([Id])
);

CREATE TABLE [EmploymentJobs] (
	[HRJobId]	INTEGER,
	[CountriesCountryId]	INTEGER,
	[JobTitle]	TEXT,
	[MinSalary]	INTEGER,
	[MaxSalary]	INTEGER,
	PRIMARY KEY([HRJobId]),
	FOREIGN KEY([CountriesCountryId]) REFERENCES [Countries]([CountryId])
);


CREATE TABLE [Inventories] (
	[InventoryId]	INTEGER,
	[ProductId]	INTEGER,
	[WarehouseId]	INTEGER,
	[QuantityOnHand]	INTEGER,
	[QuantityAvaliable]	INTEGER,
	FOREIGN KEY([ProductId]) REFERENCES [Products]([ProductId]),
	PRIMARY KEY([InventoryId])
);

CREATE TABLE [Locations] (
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


CREATE TABLE [OrderItems] (
	[OrderItemId]	INTEGER,
	[OrderId]	INTEGER,
	[ProductId]	INTEGER,
	[UnitPrice]	INTEGER,
	[Quantity]	INTEGER,
	PRIMARY KEY([OrderItemId]),
	FOREIGN KEY([ProductId]) REFERENCES [Products]([ProductId]),
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
	FOREIGN KEY([SalesRepId]) REFERENCES [CustomerCompanies]([CompanyId]),
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
	FOREIGN KEY([LocationsLocationId]) REFERENCES [Locations]([LocationId]),
PRIMARY KEY([PersonsPersonId])
);


CREATE TABLE [PhoneNumbers] (
	[PhoneNumberId]	INTEGER,
	[PeoplePersonId]	INTEGER,
	[LocationsLocationId]	INTEGER,
	[Phonenumber]	INTEGER,
	[CountryCode]	INTEGER,
	[PhoneType]	INTEGER,
	FOREIGN KEY([PeoplePersonId]) REFERENCES [People]([Id]),
	FOREIGN KEY([LocationsLocationId]) REFERENCES [Locations]([LocationId]),
	PRIMARY KEY([PhoneNumberId])
);


CREATE TABLE [Products] (
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


CREATE TABLE [RestrictedInfoes] (
	[PersonId]	INTEGER,
	[DateOfBirth]	TEXT,
	[DateOfDeath]	TEXT,
	[GovernmentId]	TEXT,
	[PassportId]	TEXT,
	[HireDire]	TEXT,
	[SeniorityCode]	INTEGER,
	FOREIGN KEY([PersonId]) REFERENCES [People]([Id]),
PRIMARY KEY([PersonId])
);


CREATE TABLE [Warehouses] (
	[WarehouseId]	INTEGER,
	[LocationId]	INTEGER,
	[WarehouseName]	TEXT,
	FOREIGN KEY([WarehouseId]) REFERENCES [Inventories]([WarehouseId]),
	FOREIGN KEY([LocationId]) REFERENCES [Locations]([LocationId]),
PRIMARY KEY([WarehouseId])
);";
                        command.CommandText = allTablesAutomated;
                        command.CommandType = System.Data.CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                
            }

            dataBase = new ApplicationContext();

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
            dataBase.People.Load();
            dataBase.PersonLocations.Load();
            dataBase.PhoneNumbers.Load();
            dataBase.Products.Load();
            dataBase.RestrictedInfo.Load();
            dataBase.Warehouses.Load();
            
            Update();
        }

        // <ADD>
        public void Add(Country obj) { dataBase.Countries.Add(obj); Update(); }
        public void Add(Customer obj) { dataBase.Customers.Add(obj); Update(); }
        public void Add(CustomerCompany obj) { dataBase.CustomerCompanies.Add(obj); Update(); }
        public void Add(CustomerEmployee obj) { dataBase.CustomerEmployees.Add(obj); Update(); }
        public void Add(Employment obj) { dataBase.Employments.Add(obj); Update(); }
        public void Add(EmploymentJobs obj) { dataBase.EmploymentJobs.Add(obj); Update(); }
        public void Add(Inventory obj) { dataBase.Inventories.Add(obj); Update(); }
        public void Add(Location obj) { dataBase.Locations.Add(obj); Update(); }
        public void Add(OrderItem obj) { dataBase.OrderItems.Add(obj); Update(); }
        public void Add(Orders obj) { dataBase.Orders.Add(obj); Update(); }
        public void Add(Person obj) { dataBase.People.Add(obj); Update(); }
        public void Add(PersonLocation obj) { dataBase.PersonLocations.Add(obj); Update(); }
        public void Add(PhoneNumber obj) { dataBase.PhoneNumbers.Add(obj); Update(); }
        public void Add(Product obj) { dataBase.Products.Add(obj); Update(); }
        public void Add(RestrictedInfo obj) { dataBase.RestrictedInfo.Add(obj); Update(); }
        public void Add(Warehouse obj) { dataBase.Warehouses.Add(obj); Update(); }
        // </ADD>


        // <EDIT>
        
        public void Edit(int id, Country obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Countries.FirstOrDefault(_ => _.CountryId == id);
                try { if (temp != null) {
                        temp.CountryName = obj.CountryName;
                        temp.CountryCode = obj.CountryCode;
                        temp.NatLangCode = obj.NatLangCode;
                        temp.CurrencyCode = obj.CurrencyCode;
                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }

        public void Edit(int id, Customer obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Customers.FirstOrDefault(_ => _.CustomerId == id);
                try { if (temp != null) {
                        temp.AccountMgrId = obj.AccountMgrId;
                        temp.IncomeLevel = obj.IncomeLevel;
                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }

        
        public void Edit(int id, CustomerCompany obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.CustomerCompanies.FirstOrDefault(_ => _.CompanyId == id);
                try { if (temp != null) {
                        temp.CompanyName = obj.CompanyName;
                        temp.CreditLimitCurrency = obj.CreditLimitCurrency;
                        temp.CompanyCreditLimit = obj.CompanyCreditLimit;

                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }

        
        public void Edit(int id, CustomerEmployee obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.CustomerEmployees.FirstOrDefault(_ => _.CustomerEmployeeId == id);
                try { if (temp != null) {

                        temp.BadgeNumber = obj.BadgeNumber;
                        temp.JobTitle = obj.JobTitle;
                        temp.Department = obj.Department;
                        temp.CreditLimit = obj.CreditLimit;
                        temp.CreditLimitCurrency = obj.CreditLimitCurrency;

                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }

        
        public void Edit(int id, Employment obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Employments.FirstOrDefault(_ => _.EmployeeId == id);
                try { if (temp != null) {

                        temp.StartDate = obj.StartDate;
                        temp.EndDate = obj.EndDate;
                        temp.Salary = temp.Salary;
                        temp.CommissionPercent = temp.CommissionPercent;
                        temp.Employmentcol = obj.Employmentcol;

                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }

        
        public void Edit(int id, EmploymentJobs obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.EmploymentJobs.FirstOrDefault(_ => _.HRJobId == id);
                try { if (temp != null) {

                        temp.JobTitle = obj.JobTitle;
                        temp.MinSalary = obj.MinSalary;
                        temp.MaxSalary = obj.MaxSalary;

                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }

        
        public void Edit(int id, Inventory obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Inventories.FirstOrDefault(_ => _.InventoryId == id);
                try { if (temp != null) {

                        temp.WarehouseId = obj.WarehouseId;
                        temp.QuantityOnHand = obj.QuantityOnHand;
                        temp.QuantityAvaliable = obj.QuantityAvaliable;

                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }

        
        public void Edit(int id, Location obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Locations.FirstOrDefault(_ => _.LocationId == id);
                try { if (temp != null) {

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

                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }

        
        public void Edit(int id, OrderItem obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.OrderItems.FirstOrDefault(_ => _.OrderItemId == id);
                try { if (temp != null) {

                        temp.UnitPrice = obj.UnitPrice;
                        temp.Quantity = obj.Quantity;

                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }

        
        public void Edit(int id, Orders obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Orders.FirstOrDefault(_ => _.OrderId == id);
                try { if (temp != null) {

                        temp.OrderDate = obj.OrderDate;
                        temp.OrderCode = obj.OrderCode;
                        temp.OrderStatus = obj.OrderStatus;
                        temp.OrderTotal = obj.OrderTotal;
                        temp.OrderCurrency = obj.OrderCurrency;
                        temp.PromotionCode = obj.PromotionCode;

                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }

        
        public void Edit(int id, Person obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.People.FirstOrDefault(_ => _.Id == id);
                try { if (temp != null) {

                        temp.FirstName = obj.FirstName;
                        temp.LastName = obj.LastName;
                        temp.MiddleName = obj.MiddleName;
                        temp.Nickname = obj.Nickname;
                        temp.NatLangCode = obj.NatLangCode;
                        temp.CultureCode = obj.CultureCode;
                        temp.Gender = obj.Gender;

                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }

        
        public void Edit(int id, PersonLocation obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.PersonLocations.FirstOrDefault(_ => _.PersonsPersonId == id);
                try { if (temp != null) {

                        temp.SubAdress = obj.SubAdress;
                        temp.LocationUsage = obj.LocationUsage;
                        temp.Notes = obj.Notes;

                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }

        
        public void Edit(int id, PhoneNumber obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.PhoneNumbers.FirstOrDefault(_ => _.PhoneNumberId == id);
                try { if (temp != null) {

                        temp.Phonenumber = obj.Phonenumber;
                        temp.CountryCode = obj.CountryCode;
                        temp.PhoneType = obj.PhoneType;

                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }

        
        public void Edit(int id, Product obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Products.FirstOrDefault(_ => _.ProductId == id);
                try { if (temp != null) {

                        temp.ProductName = obj.ProductName;
                        temp.Description = obj.Description;
                        temp.Category = obj.Category;
                        temp.WeightClass = obj.WeightClass;
                        temp.WarrantlyPeriod = obj.WarrantlyPeriod;
                        temp.SupplierId = obj.SupplierId;
                        temp.Status = obj.Status;
                        temp.ListPrice = obj.ListPrice;
                        temp.MinimumPrice = obj.MinimumPrice;
                        temp.PriceCurrency = obj.PriceCurrency;
                        temp.CatalogURL = obj.CatalogURL;

                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }

        public void Edit(int id, RestrictedInfo obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.RestrictedInfo.FirstOrDefault(_ => _.PersonId == id);
                try { if (temp != null) {

                        temp.DateOfBirth = obj.DateOfBirth;
                        temp.DateOfDeath = obj.DateOfDeath;
                        temp.GovernmentId = obj.GovernmentId;
                        temp.PassportId = obj.PassportId;
                        temp.HireDire = obj.HireDire;
                        temp.SeniorityCode = obj.SeniorityCode;

                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }

        public void Edit(int id, Warehouse obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.Warehouses.FirstOrDefault(_ => _.WarehouseId == id);
                try { if (temp != null) {

                        temp.WarehouseName = obj.WarehouseName;

                        context.SaveChanges(); } }
                catch (Exception) { /*TO DO*/ }
            }
        }


        // </EDIT>


        // <DELETE>
        public void DeleteCountry(int id) { Country obj = dataBase.Countries.Find(id); if (obj != null) { dataBase.Countries.Remove(obj); Update(); } }
        public void DeleteCustomer(int id) { Customer obj = dataBase.Customers.Find(id); if (obj != null) { dataBase.Customers.Remove(obj); Update(); } }
        public void DeleteCustomerCompany(int id) { CustomerCompany obj = dataBase.CustomerCompanies.Find(id); if (obj != null) { dataBase.CustomerCompanies.Remove(obj); Update(); } }
        public void DeleteCustomerEmployee(int id) { CustomerEmployee obj = dataBase.CustomerEmployees.Find(id); if (obj != null) { dataBase.CustomerEmployees.Remove(obj); Update(); } }
        public void DeleteEmployment(int id) { Employment obj = dataBase.Employments.Find(id); if (obj != null) { dataBase.Employments.Remove(obj); Update(); } }
        public void DeleteEmploymentJobs(int id) { EmploymentJobs obj = dataBase.EmploymentJobs.Find(id); if (obj != null) { dataBase.EmploymentJobs.Remove(obj); Update(); } }
        public void DeleteInventory(int id) { Inventory obj = dataBase.Inventories.Find(id); if (obj != null) { dataBase.Inventories.Remove(obj); Update(); } }
        public void DeleteLocation(int id) { Location obj = dataBase.Locations.Find(id); if (obj != null) { dataBase.Locations.Remove(obj); Update(); } }
        public void DeleteOrderItem(int id) { OrderItem obj = dataBase.OrderItems.Find(id); if (obj != null) { dataBase.OrderItems.Remove(obj); Update(); } }
        public void DeleteOrders(int id) { Orders obj = dataBase.Orders.Find(id); if (obj != null) { dataBase.Orders.Remove(obj); Update(); } }
        public void DeletePerson(int id) { Person obj = dataBase.People.Find(id); if (obj != null) { dataBase.People.Remove(obj); Update(); } }
        public void DeletePersonLocation(int id) { PersonLocation obj = dataBase.PersonLocations.Find(id); if (obj != null) { dataBase.PersonLocations.Remove(obj); Update(); } }
        public void DeletePhoneNumber(int id) { PhoneNumber obj = dataBase.PhoneNumbers.Find(id); if (obj != null) { dataBase.PhoneNumbers.Remove(obj); Update(); } }
        public void DeleteProduct(int id) { Product obj = dataBase.Products.Find(id); if (obj != null) { dataBase.Products.Remove(obj); Update(); } }
        public void DeleteRestrictedInfo(int id) { RestrictedInfo obj = dataBase.RestrictedInfo.Find(id); if (obj != null) { dataBase.RestrictedInfo.Remove(obj); Update(); } }
        public void DeleteWarehouse(int id) { Warehouse obj = dataBase.Warehouses.Find(id); if (obj != null) { dataBase.Warehouses.Remove(obj); Update(); } }
        // </DELETE>


        // <GET>
        public IEnumerable<Country> GetCountries() { return dataBase.Countries; }
        public IEnumerable<Customer> GetCustomers() { return dataBase.Customers; }
        public IEnumerable<CustomerCompany> GetCustomerCompanies() { return dataBase.CustomerCompanies; }
        public IEnumerable<CustomerEmployee> GetCustomerEmployees() { return dataBase.CustomerEmployees; }
        public IEnumerable<Employment> GetEmployments() { return dataBase.Employments; }
        public IEnumerable<EmploymentJobs> GetEmploymentJobs() { return dataBase.EmploymentJobs; }
        public IEnumerable<Inventory> GetInventories() { return dataBase.Inventories; }
        public IEnumerable<Location> GetLocations() { return dataBase.Locations; }
        public IEnumerable<OrderItem> GetOrderItems() { return dataBase.OrderItems; }
        public IEnumerable<Orders> GetOrders() { return dataBase.Orders; }
        public IEnumerable<Person> GetPeople() { return dataBase.People; }
        public IEnumerable<PersonLocation> GetPersonLocations() { return dataBase.PersonLocations; }
        public IEnumerable<PhoneNumber> GetPhoneNumbers() { return dataBase.PhoneNumbers; }
        public IEnumerable<Product> GetProducts() { return dataBase.Products; }
        public IEnumerable<RestrictedInfo> GetRestrictedInfo() { return dataBase.RestrictedInfo; }
        public IEnumerable<Warehouse> GetWarehouses() { return dataBase.Warehouses; }
        // </GET>

        // <GETID>
        public Country GetCountryId(int id) { Country obj = null; foreach (Country o in dataBase.Countries) { if (o.CountryId == id) { obj = o; break; } } return obj; }
        public Customer GetCustomerId(int id) { Customer obj = null; foreach (Customer o in dataBase.Customers) { if (o.CustomerId == id) { obj = o; break; } } return obj; }
        public CustomerCompany GetCustomerCompanyId(int id) { CustomerCompany obj = null; foreach (CustomerCompany o in dataBase.CustomerCompanies) { if (o.CompanyId == id) { obj = o; break; } } return obj; }
        public CustomerEmployee GetCustomerEmployeeId(int id) { CustomerEmployee obj = null; foreach (CustomerEmployee o in dataBase.CustomerEmployees) { if (o.CustomerEmployeeId == id) { obj = o; break; } } return obj; }
        public Employment GetEmploymentId(int id) { Employment obj = null; foreach (Employment o in dataBase.Employments) { if (o.EmployeeId == id) { obj = o; break; } } return obj; }
        public EmploymentJobs GetEmploymentJobsId(int id) { EmploymentJobs obj = null; foreach (EmploymentJobs o in dataBase.EmploymentJobs) { if (o.HRJobId == id) { obj = o; break; } } return obj; }
        public Inventory GetInventoryId(int id) { Inventory obj = null; foreach (Inventory o in dataBase.Inventories) { if (o.InventoryId == id) { obj = o; break; } } return obj; }
        public Location GetLocationId(int id) { Location obj = null; foreach (Location o in dataBase.Locations) { if (o.LocationId == id) { obj = o; break; } } return obj; }
        public OrderItem GetOrderItemId(int id) { OrderItem obj = null; foreach (OrderItem o in dataBase.OrderItems) { if (o.OrderItemId == id) { obj = o; break; } } return obj; }
        public Orders GetOrdersId(int id) { Orders obj = null; foreach (Orders o in dataBase.Orders) { if (o.OrderId == id) { obj = o; break; } } return obj; }
        public Person GetPersonId(int id) { Person obj = null; foreach (Person o in dataBase.People) { if (o.Id == id) { obj = o; break; } } return obj; }
        public PhoneNumber GetPhoneNumberId(int id) { PhoneNumber obj = null; foreach (PhoneNumber o in dataBase.PhoneNumbers) { if (o.PhoneNumberId == id) { obj = o; break; } } return obj; }
        public Product GetProductId(int id) { Product obj = null; foreach (Product o in dataBase.Products) { if (o.ProductId == id) { obj = o; break; } } return obj; }
        public Warehouse GetWarehouseId(int id) { Warehouse obj = null; foreach (Warehouse o in dataBase.Warehouses) { if (o.WarehouseId == id) { obj = o; break; } } return obj; }
        // </GETID>

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