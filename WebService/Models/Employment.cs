using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Employment
    {
        public int EmployeeID { get; set; }

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