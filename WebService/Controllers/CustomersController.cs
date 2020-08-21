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
        private readonly ICustomersRepository _db;

        public CustomersController(ICustomersRepository db)
        {
            this._db = db;
        }

        // GET api/Customers
        public IEnumerable<Customer> Get() { return _db.GetCustomers(); }

        // GET api/Customers/{id}
        public Customer Get(int id) { return _db.GetCustomerId(id); }

        // POST api/Customers
        public IHttpActionResult Post([FromBody]Customer value)
        {
            try
            {
                _db.Add(value);
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
                _db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Customer), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Customers/{id}
        public void Delete(int id) { _db.DeleteCustomer(id); }
    }
}