using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class PersonLocation
    {
        [Key]
        public int PersonsPersonId { get; set; }

        public int LocationsLocationId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string SubAdress { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string LocationUsage { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public string Notes { get; set; }
    }
}