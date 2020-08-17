using System.ComponentModel.DataAnnotations;
namespace WebService.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Input the first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Input the second name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Input the middle name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Input the nickname")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Input the NatLangCode")]
        public int NatLangCode { get; set; }

        [Required(ErrorMessage = "Input the culture code")]
        public int CultureCode { get; set; }

        [Required(ErrorMessage = "Input the gender")]
        public string Gender { get; set; }
    }
}