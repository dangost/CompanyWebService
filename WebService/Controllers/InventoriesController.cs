using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using WebService.Abstraction;
using System;
using WebService.DI;

namespace WebService.Controllers
{
    public class InventoriesController : ApiController
    {
        private readonly IInventoriesRepository _db;

        public InventoriesController(IInventoriesRepository db)
        {
            _db = db;
        }

        // GET api/Inventories
        public IEnumerable<Inventory> Get() { return _db.GetInventories(); }

        // GET api/Inventories/{id}
        public Inventory Get(int id) { return _db.GetInventoryId(id); }

        // POST api/Inventories
        public IHttpActionResult Post([FromBody]Inventory value) {
            try
            {
                _db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Inventory), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // PUT api/Inventories/{id}
        public IHttpActionResult Put(int id, [FromBody]Inventory value)
        {
            try
            {
                _db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Inventory), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Inventories/{id}
        public void Delete(int id) { _db.DeleteInventory(id); }
    }
}