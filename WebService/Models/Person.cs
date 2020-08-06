using System.ComponentModel.DataAnnotations;
namespace WebService.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Nickname { get; set; }

        public int NatLangCode { get; set; }

        public int CultureCode { get; set; }

        public string Gender { get; set; }
    }
}