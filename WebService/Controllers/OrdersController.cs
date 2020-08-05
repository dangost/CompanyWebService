using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class OrdersController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/Orders
        public IEnumerable<Orders> Get() { return db.GetOrders(); }

        // GET api/Orders/{id}
        public Orders Get(int id) { return db.GetOrdersId(id); }

        // POST api/Orders
        public void Post([FromBody]Orders value) { db.Add(value);}

        // PUT api/Orders/{id}
        public void Put(int id, [FromBody]Orders value) { db.Edit(id, value); }

        // DELETE api/Orders/{id}
        public void Delete(int id) { db.DeleteOrders(id); }
    }
}