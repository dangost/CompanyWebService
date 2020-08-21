using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using WebService.Abstraction;
using System;
using WebService.DI;

namespace WebService.Controllers
{
    public class EmploymentsController : ApiController
    {
        private readonly IEmploymentsRepository _db;

        public EmploymentsController(IEmploymentsRepository db)
        {
            this._db = _db;
        }

        // GET api/Employments
        public IEnumerable<Employment> Get() { return _db.GetEmployments(); }

        // GET api/Employments/{id}
        public Employment Get(int id) { return _db.GetEmploymentId(id); }

        // POST api/Employments
        public IHttpActionResult Post([FromBody]Employment value)
        {
            try
            {
                _db.Add(value);
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
                _db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Employment), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Employments/{id}
        public void Delete(int id) { _db.DeleteEmployment(id); }
    }
}