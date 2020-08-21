using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;
using WebService.Abstraction;
using System;
using WebService.DI;

namespace WebService.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductsRepository _db;

        public ProductsController(IProductsRepository db)
        {
            this._db = db;
        }

        // GET api/Products
        public IEnumerable<Product> Get() { return _db.GetProducts(); }

        // GET api/Products/{id}
        public Product Get(int id) { return _db.GetProductId(id); }

        // POST api/Products
        public IHttpActionResult Post([FromBody]Product value)
        {
            try
            {
                _db.Add(value);
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
                _db.Edit(id,value);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(nameof(Product), ex.Message);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        // DELETE api/Products/{id}
        public void Delete(int id) { _db.DeleteProduct(id); }
    }
}