using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IWarehousesRepository : IRepository<Warehouse>
    {
        void DeleteWarehouse(int id);

        IEnumerable<Warehouse> GetWarehouses();

        Warehouse GetWarehouseId(int id);
    }
}