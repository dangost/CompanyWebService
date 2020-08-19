using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IPeopleRepository : IRepository<Person>
    {
        void DeletePerson(int id);

        IEnumerable<Person> GetPeople();

        Person GetPersonId(int id);
    }
}