using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class Location
    {
        public int LocationId { get; set; }

        public int CountryId { get; set; }

        public string AdressLine1 { get; set; }

        public string AdressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string District { get; set; }

        public string PostalCode { get; set; }

        public int LocationTypeCode { get; set; }

        public string Description { get; set; }

        public string ShippingNotes { get; set; }

        public int CountriesCountry { get; set; }
    }
}