using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class CustomerCompany
    {
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int CompanyCreditLimit { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string CreditLimitCurrency { get; set; }
    }
}