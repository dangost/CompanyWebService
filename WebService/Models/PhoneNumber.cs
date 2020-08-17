using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class PhoneNumber
    {
        [Key]
        public int PhoneNumberId { get; set; }

        public int PeoplePersonId { get; set; }

        public int LocationsLocationId { get; set; }

        [Required(ErrorMessage = "Input the phonenumber")]
        public int Phonenumber { get; set; }

        [Required(ErrorMessage = "Input the coutrny code")]
        public int CountryCode { get; set; }

        [Required(ErrorMessage = "Input the phone type")]
        public int PhoneType { get; set; }
    }
}