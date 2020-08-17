using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Input the country id")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Fill the adress line 1")]
        public string AdressLine1 { get; set; }

        [Required(ErrorMessage = "Fill the adress line 2")]
        public string AdressLine2 { get; set; }

        [Required(ErrorMessage = "Input the city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Input the state")]
        public string State { get; set; }

        [Required(ErrorMessage = "Input the district")]
        public string District { get; set; }

        [Required(ErrorMessage = "Input the postal code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Input the location type code")]
        public int LocationTypeCode { get; set; }

        [Required(ErrorMessage = "Input the description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Input the shipping notes")]
        public string ShippingNotes { get; set; }

        [Required(ErrorMessage = "Input the country id")]
        public int CountriesCountryId { get; set; }
    }
}