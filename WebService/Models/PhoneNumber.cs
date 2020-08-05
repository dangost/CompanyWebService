using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class PhoneNumber
    {
        public int PhoneNumberId { get; set; }

        public int PeoplePersonId { get; set; }

        public int LocationsLocationId { get; set; }

        public int Phonenumber { get; set; }

        public int CountryCode { get; set; }

        public int PhoneType { get; set; }
    }
}