using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int NatLangCode { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string CurrencyCode { get; set; }
    }
}