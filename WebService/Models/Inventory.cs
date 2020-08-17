using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Input the warehouse id")]
        public int WarehouseId { get; set; }

        [Required(ErrorMessage = "Input the quantity on hand")]
        public int QuantityOnHand { get; set; }

        [Required(ErrorMessage = "Input the quantity avaliable")]
        public int QuantityAvaliable { get; set; }
    }
}