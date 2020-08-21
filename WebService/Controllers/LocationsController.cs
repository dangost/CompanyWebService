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
        private readonly ILocationsRepository _db;

        public LocationsController(ILocationsRepository db)
        {
            this._db = db;
        }

        // GET api/Locations
        public IEnumerable<Location> Get() { return _db.GetLocations(); }

        // GET api/Locations/{id}
        public Location Get(int id) { return _db.GetLocationId(id); }

        // POST api/Locations
        public IHttpActionResult Post([FromBody]Location value)
        {
            try
            {
                _db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Location), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // PUT api/Locations/{id}
        public IHttpActionResult Put(int id, [FromBody]Location value)
        {
            try
            {
                _db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Location), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Locations/{id}
        public void Delete(int id) { _db.DeleteLocation(id); }
    }
}