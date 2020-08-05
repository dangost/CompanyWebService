using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class PersonLocationsController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/PersonLocations
        public IEnumerable<PersonLocation> Get() { return db.GetPersonLocations(); }

        // GET api/PersonLocations/{id}
        public PersonLocation Get(int id) { return db.GetPersonLocationId(id); }

        // POST api/PersonLocations
        public void Post([FromBody]PersonLocation value) { db.Add(value);}

        // PUT api/PersonLocations/{id}
        public void Put(int id, [FromBody]PersonLocation value) { db.Edit(id, value); }

        // DELETE api/PersonLocations/{id}
        public void Delete(int id) { db.DeletePersonLocation(id); }
    }
}