using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Input the product name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Input the description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Input the category")]
        public int Category { get; set; }

        [Required(ErrorMessage = "Input the weight class")]
        public int WeightClass { get; set; }

        [Required(ErrorMessage = "Input the warrantrly period")]
        public int WarrantlyPeriod { get; set; }

        [Required(ErrorMessage = "Input the supplier id")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Input the status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Input the list price")]
        public int ListPrice { get; set; }

        [Required(ErrorMessage = "Input the minimm price")]
        public int MinimumPrice { get; set; }

        [Required(ErrorMessage = "Input the price currency")]
        public string PriceCurrency { get; set; }

        [Required(ErrorMessage = "Input the catalog URL")]
        public string CatalogURL { get; set; }
    }
}