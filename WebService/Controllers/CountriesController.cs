using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using System;

namespace WebService.Controllers
{
    public class CountriesController : ApiController
    {
        public IRepository db = RepositoryController.GetRepository();

        // GET api/Countries
        public IEnumerable<Country> Get() { return db.GetCountries(); }

        // GET api/Countries/{id}
        public Country Get(int id) { return db.GetCountryId(id); }

        // POST api/Countries
        public IHttpActionResult Post([FromBody]Country value)
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

        // PUT api/Countries/{id}
        public IHttpActionResult Put(int id, [FromBody]Country value)
        {
            try
            {
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Country), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Countries/{id}
        public void Delete(int id) { db.DeleteCountry(id); }
    }
}