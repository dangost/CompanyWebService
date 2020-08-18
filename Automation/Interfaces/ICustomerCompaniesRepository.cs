using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface ICustomerCompaniesRepository
    {
        void Load();

        void Update();

        void Add(CustomerCompany obj);

        void Edit(int id, CustomerCompany obj);

        void DeleteCountry(int id);

        IEnumerable<CustomerCompany> GetCustomerCompanies();

        CustomerCompany GetCustomerCompany(int id);
    }
}