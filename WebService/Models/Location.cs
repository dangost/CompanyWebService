using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string AdressLine1 { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string AdressLine2 { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string City { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string State { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string District { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int LocationTypeCode { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string ShippingNotes { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int CountriesCountryId { get; set; }
    }

}