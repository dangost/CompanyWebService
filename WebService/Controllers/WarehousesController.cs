using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using System;

namespace WebService.Controllers
{
    public class WarehousesController : ApiController
    {
        IRepository db = RepositoryController.GetRepository();

        // GET api/Warehouses
        public IEnumerable<Warehouse> Get() { return db.GetWarehouses(); }

        // GET api/Warehouses/{id}
        public Warehouse Get(int id) { return db.GetWarehouseId(id); }

        // POST api/Warehouses
        public IHttpActionResult Post([FromBody]Warehouse value)
        {
            try
            {
                db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Warehouse), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // PUT api/Warehouses/{id}
        public IHttpActionResult Put(int id, [FromBody]Warehouse value)
        {
            try
            {
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Warehouse), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Warehouses/{id}
        public void Delete(int id) { db.DeleteWarehouse(id); }
    }
}