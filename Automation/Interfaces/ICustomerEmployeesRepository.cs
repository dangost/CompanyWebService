using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface ICustomerEmployeesRepository
    {
        void Load();

        void Update();

        void Add(CustomerEmployee obj);

        void Edit(int id, CustomerEmployee obj);

        void DeleteCountry(int id);

        IEnumerable<CustomerEmployee> GetCustomerEmployees();

        CustomerEmployee GetCustomerEmployee(int id);
    }
}