path = r"D:\Projects\Regula\Web\CompanyWebService\Automation\Repositories"

class_names = ["Country", "Customer", "CustomerCompany", "CustomerEmployee","Employment","EmploymentJobs","Inventory","Location","OrderItem", "Orders", "Person", "PersonLocation", "PhoneNumber", "Product", "RestrictedInfo", "Warehouse"]
list_names = ["Countries", "Customers", "CustomerCompanies", "CustomerEmployees","Employments", "EmploymentJobs", "Inventories","Locations","OrderItems", "Orders", "People", "PersonLocations","PhoneNumbers", "Products", "RestrictedInfo", "Warehouses"]
id_names = ["CountryId","CustomerId","CompanyId","CustomerEmployeeId","EmployeeID","HRJobId","InventoryId","LocationId","OrderItemId","OrderId","Id","","PhoneNumberId","ProductId","","WarehouseId"]

for i in range(len(class_names)):
    temp_path = path + "\\" + list_names[i] + "Repository.cs"
    file = open(temp_path, 'w')

    file.write('''using System.Data.SQLite;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebService.Models;
using System;
using WebService.Abstraction;

namespace WebService.Realization
{
    public class ''' + list_names[i] + '''Repository : I''' + list_names[i] + '''Repository
    {
        public ''' + list_names[i] + '''Repository()
        {
            Load();
        }

        public class ApplicationContext : DbContext
        {
            public ApplicationContext() : base("DefaultConnection")
            {
            }

            public DbSet<'''+class_names[i]+'''> ''' + list_names[i] + ''' { get; set; }
        }

        ApplicationContext dataBase;

        public void Load()
        {
            SQLiteRepository.CreateBase();

            dataBase = new ApplicationContext();

            dataBase.''' + list_names[i] + '''.Load();

            Update();
        }

        public void Add('''+class_names[i]+''' obj) 
        { 
            dataBase.''' + list_names[i] + '''.Add(obj);
            Update(); 
        }

        public void Edit(int id, '''+class_names[i]+''' obj)
        {
            using (var context = new ApplicationContext())
            {
                var temp = context.''' + list_names[i] + '''.FirstOrDefault(_ => _.'''+id_names[i]+''' == id);
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

        public void Delete'''+class_names[i]+'''(int id) 
        { 
            '''+class_names[i]+''' obj = dataBase.''' + list_names[i] + '''.Find(id); 
            if (obj != null) 
            { 
                dataBase.''' + list_names[i] + '''.Remove(obj);
                Update();
            } 
        }

        public IEnumerable<'''+class_names[i]+'''> Get''' + list_names[i] + '''()
        { 
            return dataBase.''' + list_names[i] + '''; 
        }

        public '''+class_names[i]+''' Get''' + class_names[i] + '''Id(int id)
        { 
            '''+class_names[i]+''' obj = null; 
            foreach ('''+class_names[i]+''' o in dataBase.''' + list_names[i] + ''') 
            { 
                if (o.'''+id_names[i]+''' == id) 
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
''')
