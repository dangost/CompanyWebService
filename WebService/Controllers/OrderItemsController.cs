using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using System;

namespace WebService.Controllers
{
    public class OrderItemsController : ApiController
    {
        IRepository db = RepositoryController.GetRepository();

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
                ModelState.AddModelError(nameof(OrderItem), ex.Message);

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