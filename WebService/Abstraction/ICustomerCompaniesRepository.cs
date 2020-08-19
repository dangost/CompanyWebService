using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface ICustomerCompaniesRepository : IRepository<CustomerCompany>
    {
        void DeleteCustomerCompany(int id);

        IEnumerable<CustomerCompany> GetCustomerCompanies();

        CustomerCompany GetCustomerCompanyId(int id);
    }
}