using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Models;

namespace WebService.Controllers
{
    public interface IRepository : IDisposable
    {
        void Load();

        void Update();
        
        void Add(Country obj);
        void Add(Customer obj);
        void Add(CustomerCompany obj);
        void Add(CustomerEmployee obj);
        void Add(Employment obj);
        void Add(EmploymentJobs obj);
        void Add(Inventory obj);
        void Add(Location obj);
        void Add(OrderItem obj);
        void Add(Orders obj);
        void Add(Person obj);
        void Add(PersonLocation obj);
        void Add(PhoneNumber obj);
        void Add(Product obj);
        void Add(RestrictedInfo obj);
        void Add(Warehouse obj);

        void Edit(int id, Country obj);
        void Edit(int id, Customer obj);
        void Edit(int id, CustomerCompany obj);
        void Edit(int id, CustomerEmployee obj);
        void Edit(int id, Employment obj);
        void Edit(int id, EmploymentJobs obj);
        void Edit(int id, Inventory obj);
        void Edit(int id, Location obj);
        void Edit(int id, OrderItem obj);
        void Edit(int id, Orders obj);
        void Edit(int id, Person obj);
        void Edit(int id, PersonLocation obj);
        void Edit(int id, PhoneNumber obj);
        void Edit(int id, Product obj);
        void Edit(int id, RestrictedInfo obj);
        void Edit(int id, Warehouse obj);

        void DeleteCountry(int id);
        void DeleteCustomer(int id);
        void DeleteCustomerCompany(int id);
        void DeleteCustomerEmployee(int id);
        void DeleteEmployment(int id);
        void DeleteEmploymentJobs(int id);
        void DeleteInventory(int id);
        void DeleteLocation(int id);
        void DeleteOrderItem(int id);
        void DeleteOrders(int id);
        void DeletePerson(int id);
        void DeletePersonLocation(int id);
        void DeletePhoneNumber(int id);
        void DeleteProduct(int id);
        void DeleteRestrictedInfo(int id);
        void DeleteWarehouse(int id);

        IEnumerable<Country> GetCountries();
        IEnumerable<Customer> GetCustomers();
        IEnumerable<CustomerCompany> GetCustomerCompanies();
        IEnumerable<CustomerEmployee> GetCustomerEmployees();
        IEnumerable<Employment> GetEmployments();
        IEnumerable<EmploymentJobs> GetEmploymentJobs();
        IEnumerable<Inventory> GetInventories();
        IEnumerable<Location> GetLocations();
        IEnumerable<OrderItem> GetOrderItems();
        IEnumerable<Orders> GetOrders();
        IEnumerable<Person> GetPeople();
        IEnumerable<PersonLocation> GetPersonLocations();
        IEnumerable<PhoneNumber> GetPhoneNumbers();
        IEnumerable<Product> GetProducts();
        IEnumerable<RestrictedInfo> GetRestrictedInfo();
        IEnumerable<Warehouse> GetWarehouses();

        Country GetCountryId(int id);
        Customer GetCustomerId(int id);
        CustomerCompany GetCustomerCompanyId(int id);
        CustomerEmployee GetCustomerEmployeeId(int id);
        Employment GetEmploymentId(int id);
        EmploymentJobs GetEmploymentJobsId(int id);
        Inventory GetInventoryId(int id);
        Location GetLocationId(int id);
        OrderItem GetOrderItemId(int id);
        Orders GetOrdersId(int id);
        Person GetPersonId(int id);
        PhoneNumber GetPhoneNumberId(int id);
        Product GetProductId(int id);
        Warehouse GetWarehouseId(int id);
    }
}
