using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IProductsRepository : IRepository<Product>
    {
        void DeleteProduct(int id);

        IEnumerable<Product> GetProducts();

        Product GetProductId(int id);
    }
}