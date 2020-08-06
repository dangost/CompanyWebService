using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class PhoneNumber
    {
        [Key]
        public int PhoneNumberId { get; set; }

        public int PeoplePersonId { get; set; }

        public int LocationsLocationId { get; set; }

        public int Phonenumber { get; set; }

        public int CountryCode { get; set; }

        public int PhoneType { get; set; }
    }
}