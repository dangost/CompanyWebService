using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class CustomerEmployeesController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/CustomerEmployees
        public IEnumerable<CustomerEmployee> Get() { return db.GetCustomerEmployees(); }

        // GET api/CustomerEmployees/{id}
        public CustomerEmployee Get(int id) { return db.GetCustomerEmployeeId(id); }

        // POST api/CustomerEmployees
        public void Post([FromBody]CustomerEmployee value) { db.Add(value);}

        // PUT api/CustomerEmployees/{id}
        public void Put(int id, [FromBody]CustomerEmployee value) { db.Edit(id, value); }

        // DELETE api/CustomerEmployees/{id}
        public void Delete(int id) { db.DeleteCustomerEmployee(id); }
    }
}