using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

        public int ProductId { get; set; }

        public int WarehouseId { get; set; }

        public int QuantityOnHand { get; set; }

        public int QuantityAvaliable { get; set; }
    }
}