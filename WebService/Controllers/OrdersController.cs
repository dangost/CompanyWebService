using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using System;

namespace WebService.Controllers
{
    public class OrdersController : ApiController
    {
        IRepository db = RepositoryController.GetRepository();

        // GET api/Orders
        public IEnumerable<Orders> Get() { return db.GetOrders(); }

        // GET api/Orders/{id}
        public Orders Get(int id) { return db.GetOrdersId(id); }

        // POST api/Orders
        public IHttpActionResult Post([FromBody]Orders value)
        {
            try
            {
                db.Add(value);
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
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Orders), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Orders/{id}
        public void Delete(int id) { db.DeleteOrders(id); }
    }
}