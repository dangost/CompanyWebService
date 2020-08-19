using System.Data.SQLite;
using System.IO;

namespace WebService.Realization
{
    public class SQLiteRepository
    {
        static string sqLitePath = @"db\company.db";

        public static void Initialize()
        {
            if (!File.Exists(sqLitePath))
            {
                if (!Directory.Exists(@"db"))
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
        }
    }
}