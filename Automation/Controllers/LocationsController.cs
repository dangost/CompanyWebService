using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using WebService.Abstraction;
using System;
using WebService.DI;

namespace WebService.Controllers
{
    public class LocationsController : ApiController
    {
        public ILocationsRepository db;

        public LocationsController()
        {
            db = SQLiteRegistration.GetRepository(this);
        }

        // GET api/Locations
        public IEnumerable<Location> Get() { return db.GetLocations(); }

        // GET api/Locations/{id}
        public Location Get(int id) { return db.GetLocationId(id); }

        // POST api/Locations
        public IHttpActionResult Post([FromBody]Location value)
        {
            try
            {
                db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Country), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // PUT api/Locations/{id}
        public IHttpActionResult Put(int id, [FromBody]Location value)
        {
            try
            {
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Location), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Locations/{id}
        public void Delete(int id) { db.DeleteLocation(id); }
    }
}