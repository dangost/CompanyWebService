using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using WebService.Abstraction;
using System;
using WebService.DI;

namespace WebService.Controllers
{
    public class CustomersController : ApiController
    {
        public ICustomersRepository db;

        public CustomersController(ICustomersRepository _db)
        {
            db = _db;
        }

        // GET api/Customers
        public IEnumerable<Customer> Get() { return db.GetCustomers(); }

        // GET api/Customers/{id}
        public Customer Get(int id) { return db.GetCustomerId(id); }

        // POST api/Customers
        public IHttpActionResult Post([FromBody]Customer value)
        {
            try
            {
                db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Customer), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // PUT api/Customers/{id}
        public IHttpActionResult Put(int id, [FromBody]Customer value)
        {
            try
            {
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Customer), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Customers/{id}
        public void Delete(int id) { db.DeleteCustomer(id); }
    }
}