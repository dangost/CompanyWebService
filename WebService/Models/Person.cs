namespace WebService.Models
{
    public class Person
    {
        public void Create(string fisrtname, string lastname, string middlename, string nickname,int natlangcode, int colturecode, string gender )
        {
            FirstName = fisrtname;
            LastName = lastname;
            MiddleName = middlename;
            Nickname = nickname;
            NatLangCode = natlangcode;
            CultureCode = colturecode;
            Gender = gender;
        }

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