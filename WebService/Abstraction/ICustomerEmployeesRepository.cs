using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface ICustomerEmployeesRepository : IRepository<CustomerEmployee>
    {
        void DeleteCustomerEmployee(int id);

        IEnumerable<CustomerEmployee> GetCustomerEmployees();

        CustomerEmployee GetCustomerEmployeeId(int id);
    }
}