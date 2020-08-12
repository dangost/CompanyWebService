using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public double UnitPrice { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public double Quantity { get; set; }
    }
}