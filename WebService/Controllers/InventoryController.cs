using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

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
        public void Post([FromBody]Inventory value) { db.Add(value);}

        // PUT api/Inventories/{id}
        public void Put(int id, [FromBody]Inventory value) { db.Edit(id, value); }

        // DELETE api/Inventories/{id}
        public void Delete(int id) { db.DeleteInventory(id); }
    }
}