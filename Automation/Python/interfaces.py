path = r"C:\Users\danil\Desktop\Automation\Interfaces"

class_names = ["Country", "Customer", "CustomerCompany", "CustomerEmployee","Employment","EmploymentJobs","Inventory","Location","OrderItem", "Orders", "Person", "PersonLocation", "PhoneNumber", "Product", "RestrictedInfo", "Warehouse"]
list_names = ["Countries", "Customers", "CustomerCompanies", "CustomerEmployees","Employments", "EmploymentJobs", "Inventories","Locations","OrderItems", "Orders", "People", "PersonLocations","PhoneNumbers", "Products", "RestrictedInfo", "Warehouses"]

for i in range(len(class_names)):
    temp_path = path + "\\I" + list_names[i] + "Repository.cs"
    file = open(temp_path, 'w')

    file.write('''using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface I''' + list_names[i] + '''Repository
    {
        void Load();

        void Update();

        void Add('''+class_names[i]+''' obj);

        void Edit(int id, '''+class_names[i]+''' obj);

        void DeleteCountry(int id);

        IEnumerable<'''+class_names[i]+'''> Get''' + list_names[i] + '''();

        '''+class_names[i]+''' Get'''+class_names[i]+'''(int id);
    }
}''')