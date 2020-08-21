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
        private readonly ICustomerCompaniesRepository _db;

        public CustomerCompaniesController(ICustomerCompaniesRepository db)
        {
            this._db = db;
        }

        // GET api/CustomerCompanies
        public IEnumerable<CustomerCompany> Get() { return _db.GetCustomerCompanies(); }

        // GET api/CustomerCompanies/{id}
        public CustomerCompany Get(int id) { return _db.GetCustomerCompanyId(id); }

        // POST api/CustomerCompanies
        public IHttpActionResult Post([FromBody]CustomerCompany value) {
            try
            {
                _db.Add(value);
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
                _db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(CustomerCompany), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/CustomerCompanies/{id}
        public void Delete(int id) { _db.DeleteCustomerCompany(id); }
    }
}