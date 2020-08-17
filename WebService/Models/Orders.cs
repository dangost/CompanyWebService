using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int SalesRepId { get; set; }

        [Required(ErrorMessage = "Input the order date")]
        public string OrderDate { get; set; }

        [Required(ErrorMessage = "Input the order code")]
        public int OrderCode { get; set; }

        [Required(ErrorMessage = "Input the order status")]
        public string OrderStatus { get; set; }

        [Required(ErrorMessage = "Input the order total")]
        public int OrderTotal { get; set; }

        [Required(ErrorMessage = "Input the order currency")]
        public string OrderCurrency { get; set; }

        [Required(ErrorMessage = "Input the promotion code")]
        public string PromotionCode { get; set; }
    }
}