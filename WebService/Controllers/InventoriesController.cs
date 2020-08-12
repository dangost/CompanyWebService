using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using System;

namespace WebService.Controllers
{
    public class InventoriesController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/Inventories
        public IEnumerable<Inventory> Get() { return db.GetInventories(); }

        // GET api/Inventories/{id}
        public Inventory Get(int id) { return db.GetInventoryId(id); }

        // POST api/Inventories
        public IHttpActionResult Post([FromBody]Inventory value) {
            try
            {
                db.Add(value);
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
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Inventory), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Inventories/{id}
        public void Delete(int id) { db.DeleteInventory(id); }
    }
}