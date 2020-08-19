using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface ICustomersRepository : IRepository<Customer>
    {
        void DeleteCustomer(int id);

        IEnumerable<Customer> GetCustomers();

        Customer GetCustomerId(int id);
    }
}