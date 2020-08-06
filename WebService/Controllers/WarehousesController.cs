using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class WarehousesController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/Warehouses
        public IEnumerable<Warehouse> Get() { return db.GetWarehouses(); }

        // GET api/Warehouses/{id}
        public Warehouse Get(int id) { return db.GetWarehouseId(id); }

        // POST api/Warehouses
        public void Post([FromBody]Warehouse value) { db.Add(value);}

        // PUT api/Warehouses/{id}
        public void Put(int id, [FromBody]Warehouse value) { db.Edit(id, value); }

        // DELETE api/Warehouses/{id}
        public void Delete(int id) { db.DeleteWarehouse(id); }
    }
}