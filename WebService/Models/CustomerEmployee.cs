using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class CustomerEmployee
    {
        public int CustomerEmployeeId { get; set; }

        public int CompanyId { get; set; }

        public string BadgeNumber { get; set; }

        public string JobTitle { get; set; }

        public string Department { get; set; }

        public int CreditLimit { get; set; }

        public string CreditLimitCurrency { get; set; }


    }
}