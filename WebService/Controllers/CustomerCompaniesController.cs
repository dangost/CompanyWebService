using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using WebService.Abstraction;
using System;
using WebService.DI;

namespace WebService.Controllers
{
    public class CustomerCompaniesController : ApiController
    {
        public ICustomerCompaniesRepository db;

        public CustomerCompaniesController(ICustomerCompaniesRepository _db)
        {
            db = _db;
        }

        // GET api/CustomerCompanies
        public IEnumerable<CustomerCompany> Get() { return db.GetCustomerCompanies(); }

        // GET api/CustomerCompanies/{id}
        public CustomerCompany Get(int id) { return db.GetCustomerCompanyId(id); }

        // POST api/CustomerCompanies
        public IHttpActionResult Post([FromBody]CustomerCompany value) {
            try
            {
                db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(CustomerCompany), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // PUT api/CustomerCompanies/{id}
        public IHttpActionResult Put(int id, [FromBody]CustomerCompany value)
        {
            try
            {
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(CustomerCompany), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/CustomerCompanies/{id}
        public void Delete(int id) { db.DeleteCustomerCompany(id); }
    }
}