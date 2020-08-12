using System.ComponentModel.DataAnnotations;
namespace WebService.Models
{
    public class RestrictedInfo
    {
        [Key]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string DateOfDeath { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string GovernmentId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string PassportId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string HireDire { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int SeniorityCode { get; set; }
    }
}