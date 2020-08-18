using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using System;

namespace WebService.Controllers
{
    public class CustomerCompaniesController : ApiController
    {
        public IRepository db = RepositoryController.GetRepository();

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