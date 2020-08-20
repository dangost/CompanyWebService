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
        public IPeopleRepository db;

        public PeopleController(IPeopleRepository _db)
        {
            db = _db;
        }

        // GET api/People
        public IEnumerable<Person> Get() { return db.GetPeople(); }

        // GET api/People/{id}
        public Person Get(int id) { return db.GetPersonId(id); }

        // POST api/People
        public IHttpActionResult Post([FromBody]Person value)
        {
            try
            {
                db.Add(value);
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
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Person), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/People/{id}
        public void Delete(int id) { db.DeletePerson(id); }
    }
}