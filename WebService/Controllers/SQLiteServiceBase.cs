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
        

        ApplicationContext dataBase = new ApplicationContext();

        string sqLitePath = @"db\company.db";

        void Load()
        {
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
        [HttpPost] public void Add([FromBody]Country obj) { dataBase.Countries.Add(obj); Update(); }
        [HttpPost] public void Add([FromBody]Customer obj) { dataBase.Customers.Add(obj); Update(); }
        [HttpPost] public void Add([FromBody]CustomerCompany obj) { dataBase.CustomerCompanies.Add(obj); Update(); }
        [HttpPost] public void Add([FromBody]CustomerEmployee obj) { dataBase.CustomerEmployees.Add(obj); Update(); }
        [HttpPost] public void Add([FromBody]Employment obj) { dataBase.Employments.Add(obj); Update(); }
        [HttpPost] public void Add([FromBody]EmploymentJobs obj) { dataBase.EmploymentJobs.Add(obj); Update(); }
        [HttpPost] public void Add([FromBody]Inventory obj) { dataBase.Inventories.Add(obj); Update(); }
        [HttpPost] public void Add([FromBody]Location obj) { dataBase.Locations.Add(obj); Update(); }
        [HttpPost] public void Add([FromBody]OrderItem obj) { dataBase.OrderItems.Add(obj); Update(); }
        [HttpPost] public void Add([FromBody]Orders obj) { dataBase.Orders.Add(obj); Update(); }
        [HttpPost] public void Add([FromBody]Person obj) { dataBase.People.Add(obj); Update(); }
        [HttpPost] public void Add([FromBody]PersonLocation obj) { dataBase.PersonLocations.Add(obj); Update(); }
        [HttpPost] public void Add([FromBody]PhoneNumber obj) { dataBase.PhoneNumbers.Add(obj); Update(); }
        [HttpPost] public void Add([FromBody]Product obj) { dataBase.Products.Add(obj); Update(); }
        [HttpPost] public void Add([FromBody]RestrictedInfo obj) { dataBase.RestrictedInfo.Add(obj); Update(); }
        [HttpPost] public void Add([FromBody]Warehouse obj) { dataBase.Warehouses.Add(obj); Update(); }
        // </ADD>


        // <EDIT>
        [HttpPut] public void Edit(int id, [FromBody]Country obj)
        {
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source = " + sqLitePath;
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    string sqlQuerry = @"UPDATE Countries
            
            SET CountryName = '" + obj.CountryName + @"', CountryCode = '" + obj.CountryCode + @"', NatLangCode = " + obj.NatLangCode + @", CurrencyCode = '" + obj.CurrencyCode + @"'
            WHERE CountryId = " + id + @";" ;

                    command.CommandText = sqlQuerry;
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }


        [HttpPut]
        public void Edit(int id, [FromBody]Customer obj)
        {
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source = " + sqLitePath; connection.Open(); using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    string sqlQuerry = @"
UPDATE Customers 
SET
CustomerEmployeeId = " + obj.CustomerEmployeeId + @",
AccountMgrId = '" + obj.AccountMgrId + @"'
WHERE
CustomerId = " + id + @";
";

                    command.CommandText = sqlQuerry; command.CommandType = System.Data.CommandType.Text; command.ExecuteNonQuery();
                }
            }
        }
        [HttpPut]
        public void Edit(int id, [FromBody]CustomerCompany obj)
        {
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source = " + sqLitePath; connection.Open(); using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    string sqlQuerry = @"UPDATE CustomerCompanies 
SET
CompanyName = '" + obj.CompanyName + @"',
CompanyCreditLimit = " + obj.CompanyCreditLimit + @",
CreditLimitCurrency = '"+obj.CreditLimitCurrency+ @"'
WHERE
CompanyId = " + id + @";
";

                    command.CommandText = sqlQuerry; command.CommandType = System.Data.CommandType.Text; command.ExecuteNonQuery();
                }
            }
        }
        [HttpPut]
        public void Edit(int id, [FromBody]CustomerEmployee obj)
        {
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source = " + sqLitePath; connection.Open(); using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    string sqlQuerry = @"UPDATE CustomerEmployees
SET
BadgeNumber = '" + obj.BadgeNumber + @"',
JobTitle = '" + obj.JobTitle + @"',
Department = '" + obj.Department + @"',
CreditLimit = " + obj.CreditLimit + @",
CreditLimitCurrency = " + obj.CreditLimitCurrency + @"
WHERE
CustomerEmployeeId = " + id + @";
";

                    command.CommandText = sqlQuerry; command.CommandType = System.Data.CommandType.Text; command.ExecuteNonQuery();
                }
            }
        }
        [HttpPut]
        public void Edit(int id, [FromBody]Employment obj)
        {
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source = " + sqLitePath; connection.Open(); using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    string sqlQuerry = @"UPDATE Employments
SET
StartDate = '" + obj.StartDate + @"',
EndDate = '" + obj.EndDate + @"',
Salary = " + obj.Salary + @",
CommissionPercent = '" + obj.CommissionPercent + @"',
Employmentcol = '" + obj.Employmentcol + @"'
WHERE
EmployeeId = " + id + @";
";
                    command.CommandText = sqlQuerry; command.CommandType = System.Data.CommandType.Text; command.ExecuteNonQuery();
                }
            }
        }
        [HttpPut]
        public void Edit(int id, [FromBody]EmploymentJobs obj)
        {
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source = " + sqLitePath; connection.Open(); using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    string sqlQuerry = @"
UPDATE EmploymentJobs
SET
JobTitle = '" + obj.JobTitle + @"',
MinSalary = " + obj.MinSalary + @",
MaxSalary = " + obj.MaxSalary + @"
WHERE
HRJobId = " + id + @";
";


                    command.CommandText = sqlQuerry; command.CommandType = System.Data.CommandType.Text; command.ExecuteNonQuery();
                }
            }
        }
        [HttpPut]
        public void Edit(int id, [FromBody]Inventory obj)
        {
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source = " + sqLitePath; connection.Open(); using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    string sqlQuerry = @"
UPDATE EmploymentJobs
SET
WarehouseId = " + obj.WarehouseId + @",
QuantityOnHand = " + obj.QuantityOnHand + @",
QuantityAvaliable = " + obj.QuantityAvaliable + @"
WHERE
InventoryId = " + id + @";
";

                    command.CommandText = sqlQuerry; command.CommandType = System.Data.CommandType.Text; command.ExecuteNonQuery();
                }
            }
        }
        [HttpPut]
        public void Edit(int id, [FromBody]Location obj)
        {
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source = " + sqLitePath; connection.Open(); using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    string sqlQuerry = @"
UPDATE Locations
SET
CountryId = " + obj.CountryId + @",
AdressLine1 = '" + obj.AdressLine1 + @"',
AdressLine2 = '" + obj.AdressLine2 + @"',
City = '" + obj.City + @"',
State = '" + obj.State + @"',
District = '" + obj.District + @"',
PostalCode = '" + obj.PostalCode + @"',
LocationTypeCode = " + obj.LocationTypeCode + @",
Description = '" + obj.Description + @"',
ShippingNotes = '" + obj.ShippingNotes + @"'
WHERE
LocationId = " + id + @";
";

                    command.CommandText = sqlQuerry; command.CommandType = System.Data.CommandType.Text; command.ExecuteNonQuery();
                }
            }
        }
        [HttpPut]
        public void Edit(int id, [FromBody]OrderItem obj)
        {
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source = " + sqLitePath; connection.Open(); using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    string sqlQuerry = @"
UPDATE EmploymentJobs
SET
UnitPrice = " + obj.UnitPrice + @",
Quantity = " + obj.Quantity + @"
WHERE
OrderItemId = " + id + @";";

                    command.CommandText = sqlQuerry; command.CommandType = System.Data.CommandType.Text; command.ExecuteNonQuery();
                }
            }
        }
        [HttpPut]
        public void Edit(int id, [FromBody]Orders obj)
        {
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source = " + sqLitePath; connection.Open(); using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    string sqlQuerry = @"
UPDATE Locations
SET
OrderDate = '" + obj.OrderDate + @"',
OrderCode = " + obj.OrderCode + @",
OrderStatus = '" + obj.OrderStatus + @"',
OrderTotal = " + obj.OrderTotal + @",
OrderCurrency = '" + obj.OrderCurrency + @"',
PromotionCode = '" + obj.PromotionCode + @"'
WHERE
OrderId = " + id + @";
";


                    command.CommandText = sqlQuerry; command.CommandType = System.Data.CommandType.Text; command.ExecuteNonQuery();
                }
            }
        }
        [HttpPut]
        public void Edit(int id, [FromBody]Person obj)
        {
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source = " + sqLitePath; connection.Open(); using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    string sqlQuerry = @"
UPDATE Locations
SET
FirstName = '" + obj.FirstName + @"',
LastName = э" + obj.LastName + @",
MiddleName = '" + obj.MiddleName + @"',
Nickname = '" + obj.Nickname + @"',
NatLangCode = " + obj.NatLangCode + @",
Gender = '" + obj.Gender + @"',
CultureCode = " + obj.CultureCode + @"
WHERE
Id = " + id + @";";

                    command.CommandText = sqlQuerry; command.CommandType = System.Data.CommandType.Text; command.ExecuteNonQuery();
                }
            }
        }
        [HttpPut]
        public void Edit(int id, [FromBody]PhoneNumber obj)
        {
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source = " + sqLitePath; connection.Open(); using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    string sqlQuerry = @"
UPDATE Locations
SET
Phonenumber = " + obj.Phonenumber + @",
CountryCode = " + obj.CountryCode + @",
PhoneType = " + obj.PhoneType + @"
WHERE
PhoneNumberId = " + id + @";";

                    command.CommandText = sqlQuerry; command.CommandType = System.Data.CommandType.Text; command.ExecuteNonQuery();
                }
            }
        }
        [HttpPut]
        public void Edit(int id, [FromBody]Product obj)
        {
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source = " + sqLitePath; connection.Open(); using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    string sqlQuerry = @"
UPDATE Locations
SET
ProductName = '" + obj.ProductName + @"',
Description = '" + obj.Description + @"',
Category = " + obj.Category + @",
WeightClass = " + obj.WeightClass + @",
WarrantlyPeriod = " + obj.WarrantlyPeriod + @",
SupplierId  = " + obj.SupplierId + @",
Status = '" + obj.Status + @"',
ListPrice = " + obj.ListPrice + @",
MinimumPrice = " + obj.MinimumPrice + @",
PriceCurrency = '" + obj.PriceCurrency + @"',
CatalogURL = '" + obj.CatalogURL + @"',

WHERE
ProductId = " + id + @";";

                    command.CommandText = sqlQuerry; command.CommandType = System.Data.CommandType.Text; command.ExecuteNonQuery();
                }
            }
        }
        [HttpPut]
        public void Edit(int id, [FromBody]Warehouse obj)
        {
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source = " + sqLitePath; connection.Open(); using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    string sqlQuerry = @"
UPDATE Locations
SET
WarehouseName = '" + obj.WarehouseName + @"'
WHERE
PhoneNumberId = " + id + @";";

                    command.CommandText = sqlQuerry; command.CommandType = System.Data.CommandType.Text; command.ExecuteNonQuery();
                }
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