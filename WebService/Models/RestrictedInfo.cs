using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class RestrictedInfo
    {
        public int PersonId { get; set; }

        public string DateOfBirth { get; set; }

        public string DateOfDeath { get; set; }

        public string GovernmentId { get; set; }

        public string PassportId { get; set; }

        public string HireDire { get; set; }

        public int SenioriryCode { get; set; }
    }
}