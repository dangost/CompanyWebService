using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IProductsRepository
    {
        void Load();

        void Update();

        void Add(Product obj);

        void Edit(int id, Product obj);

        void DeleteCountry(int id);

        IEnumerable<Product> GetProducts();

        Product GetProduct(int id);
    }
}