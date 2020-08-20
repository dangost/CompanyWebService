path = r"D:\Projects\Regula\Web\CompanyWebService\Automation\text.txt"

class_names = ["Country", "Customer", "CustomerCompany", "CustomerEmployee","Employment","EmploymentJobs","Inventory","Location","OrderItem", "Orders", "Person", "PersonLocation", "PhoneNumber", "Product", "RestrictedInfo", "Warehouse"]
list_names = ["Countries", "Customers", "CustomerCompanies", "CustomerEmployees","Employments", "EmploymentJobs", "Inventories","Locations","OrderItems", "Orders", "People", "PersonLocations","PhoneNumbers", "Products", "RestrictedInfo", "Warehouses"]
file = open(path, 'w')
string = ""
for i in range(len(class_names)):    
    string += "Bind<I"+list_names[i]+"Repository>().To<"+list_names[i]+"Repository>();\n"

file.write(string)
file.close()
