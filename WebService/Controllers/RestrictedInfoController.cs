using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class RestrictedInfoController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/RestrictedInfo
        public IEnumerable<RestrictedInfo> Get() { return db.GetRestrictedInfo(); }

        // GET api/RestrictedInfo/{id}
        public RestrictedInfo Get(int id) { return db.GetRestrictedInfoId(id); }

        // POST api/RestrictedInfo
        public void Post([FromBody]RestrictedInfo value) { db.Add(value);}

        // PUT api/RestrictedInfo/{id}
        public void Put(int id, [FromBody]RestrictedInfo value) { db.Edit(id, value); }

        // DELETE api/RestrictedInfo/{id}
        public void Delete(int id) { db.DeleteRestrictedInfo(id); }
    }
}