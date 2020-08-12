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

        [Required(ErrorMessage = "Input the value")]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string EndDate { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string CommissionPercent { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string Employmentcol { get; set; }
    }
}