using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IOrdersRepository : IRepository<Orders>
    {
        void DeleteOrders(int id);

        IEnumerable<Orders> GetOrders();

        Orders GetOrdersId(int id);
    }
}