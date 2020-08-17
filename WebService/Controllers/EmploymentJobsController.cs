using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using System;

namespace WebService.Controllers
{
    public class EmploymentJobsController : ApiController
    {
        IRepository db = new SQLiteServiceBase();

        // GET api/EmploymentJobs
        public IEnumerable<EmploymentJobs> Get() { return db.GetEmploymentJobs(); }

        // GET api/EmploymentJobs/{id}
        public EmploymentJobs Get(int id) { return db.GetEmploymentJobsId(id); }

        // POST api/EmploymentJobs
        public IHttpActionResult Post([FromBody]EmploymentJobs value)
        {
            try
            {
                db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(EmploymentJobs), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // PUT api/EmploymentJobs/{id}
        public IHttpActionResult Put(int id, [FromBody]EmploymentJobs value)
        {
            try
            {
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(EmploymentJobs), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/EmploymentJobs/{id}
        public void Delete(int id) { db.DeleteEmploymentJobs(id); }
    }
}