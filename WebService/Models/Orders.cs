using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int SalesRepId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string OrderDate { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int OrderCode { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string OrderStatus { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int OrderTotal { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string OrderCurrency { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string PromotionCode { get; set; }
    }
}