using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IInventoriesRepository
    {
        void Load();

        void Update();

        void Add(Inventory obj);

        void Edit(int id, Inventory obj);

        void DeleteCountry(int id);

        IEnumerable<Inventory> GetInventories();

        Inventory GetInventory(int id);
    }
}