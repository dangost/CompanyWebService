using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int WarehouseId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int QuantityOnHand { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int QuantityAvaliable { get; set; }
    }
}