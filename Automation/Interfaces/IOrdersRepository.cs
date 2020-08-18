using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IOrdersRepository
    {
        void Load();

        void Update();

        void Add(Orders obj);

        void Edit(int id, Orders obj);

        void DeleteCountry(int id);

        IEnumerable<Orders> GetOrders();

        Orders GetOrders(int id);
    }
}