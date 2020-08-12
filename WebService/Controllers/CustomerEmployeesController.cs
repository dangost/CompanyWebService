using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using System;

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
        public IHttpActionResult Post([FromBody]CustomerEmployee value)
        {
            try
            {
                db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(CustomerEmployee), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // PUT api/CustomerEmployees/{id}
        public IHttpActionResult Put(int id, [FromBody]CustomerEmployee value)
        {
            try
            {
                db.Edit(id, value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(CustomerEmployee), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/CustomerEmployees/{id}
        public void Delete(int id) { db.DeleteCustomerEmployee(id); }
    }
}