using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }

        public int LocationId { get; set; }

        public string WarehouseName { get; set; }
    }
}