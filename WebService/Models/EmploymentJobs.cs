using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class EmploymentJobs
    {
        [Key]
        public int HRJobId { get; set; }

        public int CountriesCountryId { get; set; }

        [Required(ErrorMessage = "Input the job title")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Input the min salary")]
        public int MinSalary { get; set; }

        [Required(ErrorMessage = "Input the max salary")]
        public int MaxSalary { get; set; }
    }
}