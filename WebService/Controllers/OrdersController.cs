using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using WebService.Abstraction;
using System;
using WebService.DI;

namespace WebService.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IOrdersRepository _db;

        public OrdersController(IOrdersRepository db)
        {
            this._db = db;
        }

        // GET api/Orders
        public IEnumerable<Orders> Get() { return _db.GetOrders(); }

        // GET api/Orders/{id}
        public Orders Get(int id) { return _db.GetOrdersId(id); }

        // POST api/Orders
        public IHttpActionResult Post([FromBody]Orders value)
        {
            try
            {
                _db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Orders), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // PUT api/Orders/{id}
        public IHttpActionResult Put(int id, [FromBody]Orders value)
        {
            try
            {
                _db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Orders), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Orders/{id}
        public void Delete(int id) { _db.DeleteOrders(id); }
    }
}