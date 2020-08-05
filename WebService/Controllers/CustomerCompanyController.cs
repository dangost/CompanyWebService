using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class CustomerCompaniesController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/CustomerCompanies
        public IEnumerable<CustomerCompany> Get() { return db.GetCustomerCompanies(); }

        // GET api/CustomerCompanies/{id}
        public CustomerCompany Get(int id) { return db.GetCustomerCompanyId(id); }

        // POST api/CustomerCompanies
        public void Post([FromBody]CustomerCompany value) { db.Add(value);}

        // PUT api/CustomerCompanies/{id}
        public void Put(int id, [FromBody]CustomerCompany value) { db.Edit(id, value); }

        // DELETE api/CustomerCompanies/{id}
        public void Delete(int id) { db.DeleteCustomerCompany(id); }
    }
}