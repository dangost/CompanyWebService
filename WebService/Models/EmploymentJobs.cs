using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class EmploymentJobs
    {
        public int HRJobId { get; set; }

        public int CountriesCountryId { get; set; }

        public string JobTitle { get; set; }

        public int MinSalary { get; set; }

        public int MaxSalary { get; set; }
    }
}