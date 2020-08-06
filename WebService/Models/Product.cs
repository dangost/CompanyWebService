using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public int Category { get; set; }

        public int WeightClass { get; set; }

        public int WarrantlyPeriod { get; set; }

        public int SupplierId { get; set; }

        public string Status { get; set; }

        public int ListPrice { get; set; }

        public int MinimumPrice { get; set; }

        public string PriceCurrency { get; set; }

        public string CatalogURL { get; set; }
    }
}