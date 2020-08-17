using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class CustomerCompany
    {
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Input the company name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Input the credit limit")]
        public int CompanyCreditLimit { get; set; }

        [Required(ErrorMessage = "Input the limit currency")]
        public string CreditLimitCurrency { get; set; }
    }
}