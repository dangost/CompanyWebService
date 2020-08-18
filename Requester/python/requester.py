import requests
from python import data

data = data.Data()
ll = r"result.txt"
list_names = ["Countries", "Customers", "CustomerCompanies", "CustomerEmployees", "Employments", "EmploymentJobs", "Inventories", "Locations","OrderItems", "Orders", "People", "PersonLocations","PhoneNumbers", "Products", "RestrictedInfo", "Warehouses"]

valid_list = [data.country_valid_json, data.customer_company_valid_json, data.customer_company_valid_json, data.customer_employee_valid_json, data.employment_valid_json, data.employment_jobs_valid_json, data.inventory_valid_json, data.location_valid_json, data.order_item_valid_json, data.orders_valid_json, data.person_valid_json, data.person_location_valid_json, data.phone_number_valid_json, data.product_valid_json, data.restricted_valid_json, data.warehouse_valid_json]
invalid_list = [data.country_invalid_json, data.customer_company_invalid_json, data.customer_company_invalid_json, data.customer_employee_invalid_json, data.employment_invalid_json, data.employment_jobs_invalid_json, data.inventory_invalid_json, data.location_invalid_json, data.order_item_invalid_json, data.orders_invalid_json, data.person_invalid_json, data.person_location_invalid_json, data.phone_number_invalid_json, data.product_invalid_json, data.restricted_invalid_json, data.warehouse_invalid_json]

file = open(ll, 'w')
for i in range(len(list_names)):
    link = r"http://localhost:59468/api/"+list_names[i]
    file.write("\n\n\n"+list_names[i]+"\n")
    file.write("\n")
    file.write(requests.get(link).text)
    file.write("\n")
    file.write(requests.post(link, json=valid_list[i]).text)
    file.write("\n")
    file.write(requests.post(link, json=valid_list[i]).text)
    file.write("\n")
    file.write(requests.put(link + r'/1', invalid_list[i]).text)
    file.write("\n")
    file.write(requests.get(link).text)
    file.write("\n")
    file.write(requests.delete(link + r'/1',).text)
    file.write("\n")
    file.write(requests.get(link).text)
    file.write("\n")