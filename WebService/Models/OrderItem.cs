using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Input the unit price")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "Input the quantity")]
        public double Quantity { get; set; }
    }
}