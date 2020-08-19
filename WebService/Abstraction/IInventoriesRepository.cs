using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IInventoriesRepository : IRepository<Inventory>
    {
        void DeleteInventory(int id);

        IEnumerable<Inventory> GetInventories();

        Inventory GetInventoryId(int id);
    }
}