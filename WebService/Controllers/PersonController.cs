using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class PersonConrioller : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        [Route("api/{controller}")]
        public IEnumerable<Person> Get()
        {
            return db.GetPeople();
        }

        [Route("api/{controller}/{id}")]
        public Person Get(int id)
        {
            return db.GetPersonId(id);
        }


        [HttpPost]
        public void Post([FromBody]Person value)
        {
            db.Add(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [Route("api/{controller}/Delete/{id}")]
        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}