using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IPersonLocationsRepository : IRepository<PersonLocation>
    {
        void DeletePersonLocation(int id);

        IEnumerable<PersonLocation> GetPersonLocations();

        PersonLocation GetPersonLocationId(int id);
    }
}