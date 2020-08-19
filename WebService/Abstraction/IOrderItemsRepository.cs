using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IOrderItemsRepository : IRepository<OrderItem>
    {
        void DeleteOrderItem(int id);

        IEnumerable<OrderItem> GetOrderItems();

        OrderItem GetOrderItemId(int id);
    }
}