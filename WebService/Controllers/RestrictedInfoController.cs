using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using System;

namespace WebService.Controllers
{
    public class RestrictedInfoController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/RestrictedInfo
        public IEnumerable<RestrictedInfo> Get() { return db.GetRestrictedInfo(); }

        // GET api/RestrictedInfo/{id}
        //public RestrictedInfo Get(int id) { return db.GetRestrictedInfoId(id); }

        // POST api/RestrictedInfo
        public IHttpActionResult Post([FromBody]RestrictedInfo value)
        {
            try
            {
                db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(RestrictedInfo), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // PUT api/RestrictedInfo/{id}
        public IHttpActionResult Put(int id, [FromBody]RestrictedInfo value)
        {
            try
            {
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(RestrictedInfo), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/RestrictedInfo/{id}
        public void Delete(int id) { db.DeleteRestrictedInfo(id); }
    }
}