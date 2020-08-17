using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }

        public int LocationId { get; set; }

        [Required(ErrorMessage = "Input the warehouse name")]
        public string WarehouseName { get; set; }
    }
}