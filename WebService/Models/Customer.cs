using System.ComponentModel.DataAnnotations;
namespace WebService.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public int PersonId { get; set; }

        public int CustomerEmployeeId { get; set; }

        [Required(ErrorMessage = "Input the account id")]
        public int AccountMgrId { get; set; }

        [Required(ErrorMessage = "Input the level")]
        public int IncomeLevel { get; set; }
    }
}