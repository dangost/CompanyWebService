using System.ComponentModel.DataAnnotations;
namespace WebService.Models
{
    public class RestrictedInfo
    {
        [Key]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Input the adte of birth")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Input the date of death")]
        public string DateOfDeath { get; set; }

        [Required(ErrorMessage = "Input the government")]
        public string GovernmentId { get; set; }

        [Required(ErrorMessage = "Input the passport id")]
        public string PassportId { get; set; }

        [Required(ErrorMessage = "Input the hiredire")]
        public string HireDire { get; set; }

        [Required(ErrorMessage = "Input the senioriry code")]
        public int SeniorityCode { get; set; }
    }
}