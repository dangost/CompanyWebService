using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class EmploymentJobsController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/EmploymentJobs
        public IEnumerable<EmploymentJobs> Get() { return db.GetEmploymentJobs(); }

        // GET api/EmploymentJobs/{id}
        public EmploymentJobs Get(int id) { return db.GetEmploymentJobsId(id); }

        // POST api/EmploymentJobs
        public void Post([FromBody]EmploymentJobs value) { db.Add(value);}

        // PUT api/EmploymentJobs/{id}
        public void Put(int id, [FromBody]EmploymentJobs value) { db.Edit(id, value); }

        // DELETE api/EmploymentJobs/{id}
        public void Delete(int id) { db.DeleteEmploymentJobs(id); }
    }
}