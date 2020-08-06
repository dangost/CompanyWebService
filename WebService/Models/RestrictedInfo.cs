using System.ComponentModel.DataAnnotations;
namespace WebService.Models
{
    public class RestrictedInfo
    {
        [Key]
        public int PersonId { get; set; }

        public string DateOfBirth { get; set; }

        public string DateOfDeath { get; set; }

        public string GovernmentId { get; set; }

        public string PassportId { get; set; }

        public string HireDire { get; set; }

        public int SeniorityCode { get; set; }
    }
}