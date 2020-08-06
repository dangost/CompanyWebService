using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class EmploymentsController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/Employments
        public IEnumerable<Employment> Get() { return db.GetEmployments(); }

        // GET api/Employments/{id}
        public Employment Get(int id) { return db.GetEmploymentId(id); }

        // POST api/Employments
        public void Post([FromBody]Employment value) { db.Add(value);}

        // PUT api/Employments/{id}
        public void Put(int id, [FromBody]Employment value) { db.Edit(id, value); }

        // DELETE api/Employments/{id}
        public void Delete(int id) { db.DeleteEmployment(id); }
    }
}