using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public string CountryCode { get; set; }

        public int NatLangCode { get; set; }

        public string CurrencyCode { get; set; }
    }
}