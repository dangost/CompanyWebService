using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using System;

namespace WebService.Controllers
{
    public class ProductsController : ApiController
    {
        IRepository db = new SQLiteServiceBase();

        // GET api/Products
        public IEnumerable<Product> Get() { return db.GetProducts(); }

        // GET api/Products/{id}
        public Product Get(int id) { return db.GetProductId(id); }

        // POST api/Products
        public IHttpActionResult Post([FromBody]Product value)
        {
            try
            {
                db.Add(value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Product), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // PUT api/Products/{id}
        public IHttpActionResult Put(int id, [FromBody]Product value)
        {
            try
            {
                db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Product), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Products/{id}
        public void Delete(int id) { db.DeleteProduct(id); }
    }
}