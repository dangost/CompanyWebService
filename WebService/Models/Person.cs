using System.ComponentModel.DataAnnotations;
namespace WebService.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int NatLangCode { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int CultureCode { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string Gender { get; set; }
    }
}