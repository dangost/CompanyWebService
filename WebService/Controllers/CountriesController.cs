using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using WebService.Abstraction;
using System;
using WebService.DI;

namespace WebService.Controllers
{
    public class CountriesController : ApiController
    {
        private readonly ICountriesRepository _db;

        public CountriesController(ICountriesRepository db)
        {
            this._db = db;
        }

        // GET api/Countries
        public IEnumerable<Country> Get() { return _db.GetCountries(); }

        // GET api/Countries/{id}
        public Country Get(int id) { return _db.GetCountryId(id); }

        // POST api/Countries
        public IHttpActionResult Post([FromBody]Country value)
        {
            try
            {
                _db.Add(value);
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
                _db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Country), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Countries/{id}
        public void Delete(int id) { _db.DeleteCountry(id); }
    }
}