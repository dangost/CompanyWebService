using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class CustomerEmployee
    {
        [Key]
        public int CustomerEmployeeId { get; set; }

        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Input the number")]
        public string BadgeNumber { get; set; }

        [Required(ErrorMessage = "Input the job title")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Input the department")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Input the credit limit")]
        public int CreditLimit { get; set; }

        [Required(ErrorMessage = "Input the limit currency")]
        public string CreditLimitCurrency { get; set; }


    }
}