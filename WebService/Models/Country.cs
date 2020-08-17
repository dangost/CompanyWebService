using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Input the coutry name")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Input the code")]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "Input the code")]
        public int NatLangCode { get; set; }

        [Required(ErrorMessage = "Input the currency")]
        public string CurrencyCode { get; set; }
    }
}