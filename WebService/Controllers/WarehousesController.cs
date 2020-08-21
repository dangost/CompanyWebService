using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using WebService.Abstraction;
using System;
using WebService.DI;

namespace WebService.Controllers
{
    public class WarehousesController : ApiController
    {
        private readonly IWarehousesRepository _db;

        public WarehousesController(IWarehousesRepository db)
        {
            this._db = db;
        }
        // GET api/Warehouses
        public IEnumerable<Warehouse> Get() { return _db.GetWarehouses(); }

        // GET api/Warehouses/{id}
        public Warehouse Get(int id) { return _db.GetWarehouseId(id); }

        // POST api/Warehouses
        public IHttpActionResult Post([FromBody]Warehouse value)
        {
            try
            {
                _db.Add(value);
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
                _db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Warehouse), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Warehouses/{id}
        public void Delete(int id) { _db.DeleteWarehouse(id); }
    }
}