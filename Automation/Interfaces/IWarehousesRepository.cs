using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IWarehousesRepository
    {
        void Load();

        void Update();

        void Add(Warehouse obj);

        void Edit(int id, Warehouse obj);

        void DeleteCountry(int id);

        IEnumerable<Warehouse> GetWarehouses();

        Warehouse GetWarehouse(int id);
    }
}