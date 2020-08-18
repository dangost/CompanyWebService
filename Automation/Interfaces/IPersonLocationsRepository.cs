using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IPersonLocationsRepository
    {
        void Load();

        void Update();

        void Add(PersonLocation obj);

        void Edit(int id, PersonLocation obj);

        void DeleteCountry(int id);

        IEnumerable<PersonLocation> GetPersonLocations();

        PersonLocation GetPersonLocation(int id);
    }
}