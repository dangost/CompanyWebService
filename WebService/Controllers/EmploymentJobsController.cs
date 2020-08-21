using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using WebService.Abstraction;
using System;
using WebService.DI;

namespace WebService.Controllers
{
    public class EmploymentJobsController : ApiController
    {
        private readonly IEmploymentJobsRepository _db;

        public EmploymentJobsController(IEmploymentJobsRepository db)
        {
            this._db = db;
        }

        // GET api/EmploymentJobs
        public IEnumerable<EmploymentJobs> Get() { return _db.GetEmploymentJobs(); }

        // GET api/EmploymentJobs/{id}
        public EmploymentJobs Get(int id) { return _db.GetEmploymentJobsId(id); }

        // POST api/EmploymentJobs
        public IHttpActionResult Post([FromBody]EmploymentJobs value)
        {
            try
            {
                _db.Add(value);
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
                _db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(EmploymentJobs), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/EmploymentJobs/{id}
        public void Delete(int id) { _db.DeleteEmploymentJobs(id); }
    }
}