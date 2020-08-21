using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using WebService.Abstraction;
using System;
using WebService.DI;

namespace WebService.Controllers
{
    public class PeopleController : ApiController
    {
        private readonly IPeopleRepository _db;

        public PeopleController(IPeopleRepository db)
        {
            this._db = db;
        }

        // GET api/People
        public IEnumerable<Person> Get() { return _db.GetPeople(); }

        // GET api/People/{id}
        public Person Get(int id) { return _db.GetPersonId(id); }

        // POST api/People
        public IHttpActionResult Post([FromBody]Person value)
        {
            try
            {
                _db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Person), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // PUT api/People/{id}
        public IHttpActionResult Put(int id, [FromBody]Person value)
        {
            try
            {
                _db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Person), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/People/{id}
        public void Delete(int id) { _db.DeletePerson(id); }
    }
}