using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using WebService.Abstraction;
using System;
using WebService.DI;

namespace WebService.Controllers
{
    public class PhoneNumbersController : ApiController
    {
        public IPhoneNumbersRepository db;

        public PhoneNumbersController()
        {
            db = SQLiteRegistration.GetRepository(this);
        }

        // GET api/PhoneNumbers
        public IEnumerable<PhoneNumber> Get() { return db.GetPhoneNumbers(); }

        // GET api/PhoneNumbers/{id}
        public PhoneNumber Get(int id) { return db.GetPhoneNumberId(id); }

        // POST api/PhoneNumbers
        public IHttpActionResult Post([FromBody]PhoneNumber value)
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

        // PUT api/PhoneNumbers/{id}
        public IHttpActionResult Put(int id, [FromBody]PhoneNumber value)
        {
            try
            {
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(PhoneNumber), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/PhoneNumbers/{id}
        public void Delete(int id) { db.DeletePhoneNumber(id); }
    }
}