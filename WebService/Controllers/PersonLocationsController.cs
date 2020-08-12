using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using System;

namespace WebService.Controllers
{
    public class PersonLocationsController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/PersonLocations
        public IEnumerable<PersonLocation> Get() { return db.GetPersonLocations(); }

        // GET api/PersonLocations/{id}
        //public PersonLocation Get(int id) { return db.GetPersonLocationId(id); }

        // POST api/PersonLocations
        public IHttpActionResult Post([FromBody]PersonLocation value)
        {
            try
            {
                db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(PersonLocation), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // PUT api/PersonLocations/{id}
        public IHttpActionResult Put(int id, [FromBody]PersonLocation value)
        {
            try
            {
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(PersonLocation), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/PersonLocations/{id}
        public void Delete(int id) { db.DeletePersonLocation(id); }
    }
}