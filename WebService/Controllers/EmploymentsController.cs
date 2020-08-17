using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using System;

namespace WebService.Controllers
{
    public class EmploymentsController : ApiController
    {
        IRepository db = new SQLiteServiceBase();

        // GET api/Employments
        public IEnumerable<Employment> Get() { return db.GetEmployments(); }

        // GET api/Employments/{id}
        public Employment Get(int id) { return db.GetEmploymentId(id); }

        // POST api/Employments
        public IHttpActionResult Post([FromBody]Employment value)
        {
            try
            {
                db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Employment), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // PUT api/Employments/{id}
        public IHttpActionResult Put(int id, [FromBody]Employment value)
        {
            try
            {
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Employment), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Employments/{id}
        public void Delete(int id) { db.DeleteEmployment(id); }
    }
}