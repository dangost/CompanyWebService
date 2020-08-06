using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public double UnitPrice { get; set; }

        public double Quantity { get; set; }
    }
}