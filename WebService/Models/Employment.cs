using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Employment
    {
        public int EmployeeId { get; set; }

        public int PersonId { get; set; }

        public int HRJobId { get; set; }

        public int ManagerEmployeeId { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public int Salary { get; set; }

        public string CommissionPercent { get; set; }

        public string Employmentcol { get; set; }
    }
}