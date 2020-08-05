using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class PhoneNumbersController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/PhoneNumbers
        public IEnumerable<PhoneNumber> Get() { return db.GetPhoneNumbers(); }

        // GET api/PhoneNumbers/{id}
        public PhoneNumber Get(int id) { return db.GetPhoneNumberId(id); }

        // POST api/PhoneNumbers
        public void Post([FromBody]PhoneNumber value) { db.Add(value);}

        // PUT api/PhoneNumbers/{id}
        public void Put(int id, [FromBody]PhoneNumber value) { db.Edit(id, value); }

        // DELETE api/PhoneNumbers/{id}
        public void Delete(int id) { db.DeletePhoneNumber(id); }
    }
}