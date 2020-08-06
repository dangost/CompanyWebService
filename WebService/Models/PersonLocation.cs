using System.ComponentModel.DataAnnotations;

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