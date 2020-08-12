using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class CustomerEmployee
    {
        [Key]
        public int CustomerEmployeeId { get; set; }

        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string BadgeNumber { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int CreditLimit { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string CreditLimitCurrency { get; set; }


    }
}