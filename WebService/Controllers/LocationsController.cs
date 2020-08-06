using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class LocationsController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/Locations
        public IEnumerable<Location> Get() { return db.GetLocations(); }

        // GET api/Locations/{id}
        public Location Get(int id) { return db.GetLocationId(id); }

        // POST api/Locations
        public void Post([FromBody]Location value) { db.Add(value);}

        // PUT api/Locations/{id}
        public void Put(int id, [FromBody]Location value) { db.Edit(id, value); }

        // DELETE api/Locations/{id}
        public void Delete(int id) { db.DeleteLocation(id); }
    }
}