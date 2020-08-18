using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface ICustomersRepository
    {
        void Load();

        void Update();

        void Add(Customer obj);

        void Edit(int id, Customer obj);

        void DeleteCountry(int id);

        IEnumerable<Customer> GetCustomers();

        Customer GetCustomer(int id);
    }
}