using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class CustomerCompany
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public int CompanyCreditLimit { get; set; }

        public string CreditLimitCurrency { get; set; }
    }
}