using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using WebService.Abstraction;
using System;
using WebService.DI;

namespace WebService.Controllers
{
    public class RestrictedInfoController : ApiController
    {
        public IRestrictedInfoRepository db;

        public RestrictedInfoController()
        {
            db = SQLiteRegistration.GetRepository(this);
        }

        // GET api/RestrictedInfo
        public IEnumerable<RestrictedInfo> Get() { return db.GetRestrictedInfo(); }

        // GET api/RestrictedInfo/{id}
        public RestrictedInfo Get(int id) { return db.GetRestrictedInfoId(id); }

        // POST api/RestrictedInfo
        public IHttpActionResult Post([FromBody]RestrictedInfo value)
        {
            try
            {
                db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Country), ex.Message);

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