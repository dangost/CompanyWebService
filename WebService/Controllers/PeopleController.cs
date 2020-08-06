using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class PeopleController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/People
        public IEnumerable<Person> Get() { return db.GetPeople(); }

        // GET api/People/{id}
        public Person Get(int id) { return db.GetPersonId(id); }

        // POST api/People
        public void Post([FromBody]Person value) { db.Add(value);}

        // PUT api/People/{id}
        public void Put(int id, [FromBody]Person value) { db.Edit(id, value); }

        // DELETE api/People/{id}
        public void Delete(int id) { db.DeletePerson(id); }
    }
}