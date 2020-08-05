using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class PersonLocation
    {
        public int PersonsPersonId { get; set; }

        public int LocationsLocationId { get; set; }

        public string SubAdress { get; set; }

        public string LocationUsage { get; set; }

        public string Notes { get; set; }
    }
}