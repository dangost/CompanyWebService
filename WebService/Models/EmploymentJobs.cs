using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class EmploymentJobs
    {
        [Key]
        public int HRJobId { get; set; }

        public int CountriesCountryId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int MinSalary { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int MaxSalary { get; set; }
    }
}