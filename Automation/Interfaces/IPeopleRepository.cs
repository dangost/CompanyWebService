using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IPeopleRepository
    {
        void Load();

        void Update();

        void Add(Person obj);

        void Edit(int id, Person obj);

        void DeleteCountry(int id);

        IEnumerable<Person> GetPeople();

        Person GetPerson(int id);
    }
}