using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class CustomersController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/Customers
        public IEnumerable<Customer> Get() { return db.GetCustomers(); }

        // GET api/Customers/{id}
        public Customer Get(int id) { return db.GetCustomerId(id); }

        // POST api/Customers
        public void Post([FromBody]Customer value) { db.Add(value);}

        // PUT api/Customers/{id}
        public void Put(int id, [FromBody]Customer value) { db.Edit(id, value); }

        // DELETE api/Customers/{id}
        public void Delete(int id) { db.DeleteCustomer(id); }
    }
}