using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class EmploymentJobs
    {
        [Key]
        public int HRJobId { get; set; }

        public int CountriesCountryId { get; set; }

        public string JobTitle { get; set; }

        public int MinSalary { get; set; }

        public int MaxSalary { get; set; }
    }
}