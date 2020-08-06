using System.ComponentModel.DataAnnotations;
namespace WebService.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public int PersonId { get; set; }

        public int CustomerEmployeeId { get; set; }

        public int AccountMgrId { get; set; }

        public int IncomeLevel { get; set; }
    }
}