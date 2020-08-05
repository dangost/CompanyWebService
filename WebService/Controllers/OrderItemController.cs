using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class OrderItemsController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/OrderItems
        public IEnumerable<OrderItem> Get() { return db.GetOrderItems(); }

        // GET api/OrderItems/{id}
        public OrderItem Get(int id) { return db.GetOrderItemId(id); }

        // POST api/OrderItems
        public void Post([FromBody]OrderItem value) { db.Add(value);}

        // PUT api/OrderItems/{id}
        public void Put(int id, [FromBody]OrderItem value) { db.Edit(id, value); }

        // DELETE api/OrderItems/{id}
        public void Delete(int id) { db.DeleteOrderItem(id); }
    }
}