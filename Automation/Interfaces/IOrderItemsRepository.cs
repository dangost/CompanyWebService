using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IOrderItemsRepository
    {
        void Load();

        void Update();

        void Add(OrderItem obj);

        void Edit(int id, OrderItem obj);

        void DeleteCountry(int id);

        IEnumerable<OrderItem> GetOrderItems();

        OrderItem GetOrderItem(int id);
    }
}