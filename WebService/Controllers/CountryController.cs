using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class CountriesController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/Countries
        public IEnumerable<Country> Get() { return db.GetCountries(); }

        // GET api/Countries/{id}
        public Country Get(int id) { return db.GetCountryId(id); }

        // POST api/Countries
        public void Post([FromBody]Country value) { db.Add(value);}

        // PUT api/Countries/{id}
        public void Put(int id, [FromBody]Country value) { db.Edit(id, value); }

        // DELETE api/Countries/{id}
        public void Delete(int id) { db.DeleteCountry(id); }
    }
}