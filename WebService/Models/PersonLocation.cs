using System.ComponentModel.DataAnnotations;

namespace WebService.Models
{
    public class PersonLocation
    {
        [Key]
        public int PersonsPersonId { get; set; }

        public int LocationsLocationId { get; set; }

        [Required(ErrorMessage = "Input the sub adress")]
        public string SubAdress { get; set; }

        [Required(ErrorMessage = "Input the location usage")]
        public string LocationUsage { get; set; }

        [Required(ErrorMessage = "Input the notes")]
        public string Notes { get; set; }
    }
}