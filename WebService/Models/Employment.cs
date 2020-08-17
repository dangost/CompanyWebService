using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class Employment
    {
        [Key]
        public int EmployeeId { get; set; }

        public int PersonId { get; set; }

        public int HRJobId { get; set; }

        public int ManagerEmployeeId { get; set; }

        [Required(ErrorMessage = "Input the start date")]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "Input the end date")]
        public string EndDate { get; set; }

        [Required(ErrorMessage = "Input the salary")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Input the comission")]
        public string CommissionPercent { get; set; }

        [Required(ErrorMessage = "Input the employment")]
        public string Employmentcol { get; set; }
    }
}