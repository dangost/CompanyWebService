using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class PeopleController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/people
        public IEnumerable<Person> Get()
        {
            return db.GetPeople();
        }

        // GET api/people/{id}
        public Person Get(int id)
        {
            return db.GetPersonId(id);
        }

        // POST api/people
        public void Post([FromBody]Person value)
        {
            db.Add(value);
        }

        // PUT api/people/5
        public void Put(int id, [FromBody]Person value)
        {
            
        }

        // DELETE api/people/{id}
        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}