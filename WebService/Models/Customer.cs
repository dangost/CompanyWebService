using System.ComponentModel.DataAnnotations;
namespace WebService.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public int PersonId { get; set; }

        public int CustomerEmployeeId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int AccountMgrId { get; set; }

        [Required(ErrorMessage = "Input the value")]
        public int IncomeLevel { get; set; }
    }
}