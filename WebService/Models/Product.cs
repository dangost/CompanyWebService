using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int Category { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int WeightClass { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int WarrantlyPeriod { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int ListPrice { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int MinimumPrice { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string PriceCurrency { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string CatalogURL { get; set; }
    }
}