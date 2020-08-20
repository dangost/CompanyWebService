using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using WebService.Abstraction;
using System;
using WebService.DI;

namespace WebService.Controllers
{
    public class OrderItemsController : ApiController
    {
        public IOrderItemsRepository db;

        public OrderItemsController()
        {
            db = SQLiteRegistration.GetRepository(this);
        }

        // GET api/OrderItems
        public IEnumerable<OrderItem> Get() { return db.GetOrderItems(); }

        // GET api/OrderItems/{id}
        public OrderItem Get(int id) { return db.GetOrderItemId(id); }

        // POST api/OrderItems
        public IHttpActionResult Post([FromBody]OrderItem value)
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

        // PUT api/OrderItems/{id}
        public IHttpActionResult Put(int id, [FromBody]OrderItem value)
        {
            try
            {
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(OrderItem), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/OrderItems/{id}
        public void Delete(int id) { db.DeleteOrderItem(id); }
    }
}