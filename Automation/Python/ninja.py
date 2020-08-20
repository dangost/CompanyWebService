path = r"D:\Projects\Regula\Web\CompanyWebService\Automation\getrep.txt"

class_names = ["Country", "Customer", "CustomerCompany", "CustomerEmployee","Employment","EmploymentJobs","Inventory","Location","OrderItem", "Orders", "Person", "PersonLocation", "PhoneNumber", "Product", "RestrictedInfo", "Warehouse"]
list_names = ["Countries", "Customers", "CustomerCompanies", "CustomerEmployees","Employments", "EmploymentJobs", "Inventories","Locations","OrderItems", "Orders", "People", "PersonLocations","PhoneNumbers", "Products", "RestrictedInfo", "Warehouses"]
id_names = ["CountryId","CustomerId","CompanyId","CustomerEmployeeId","EmployeeID","HRJobId","InventoryId","LocationId","OrderItemId","OrderId","Id","","PhoneNumberId","ProductId","","WarehouseId"]
file = open(path, 'w')
string = ""
for i in range(len(class_names)):    
    string += '''public static I'''+list_names[i]+'''Repository GetRepository('''+list_names[i]+'''Controller controller)
{
    return new '''+list_names[i]+'''Repository();
}

'''

file.write(string)
file.close()
