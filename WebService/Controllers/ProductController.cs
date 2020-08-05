using System.Collections.Generic;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class ProductsController : ApiController
    {
        SQLiteServiceBase db = new SQLiteServiceBase();

        // GET api/Products
        public IEnumerable<Product> Get() { return db.GetProducts(); }

        // GET api/Products/{id}
        public Product Get(int id) { return db.GetProductId(id); }

        // POST api/Products
        public void Post([FromBody]Product value) { db.Add(value);}

        // PUT api/Products/{id}
        public void Put(int id, [FromBody]Product value) { db.Edit(id, value); }

        // DELETE api/Products/{id}
        public void Delete(int id) { db.DeleteProduct(id); }
    }
}