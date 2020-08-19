using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface ILocationsRepository : IRepository<Location>
    {
        void DeleteLocation(int id);

        IEnumerable<Location> GetLocations();

        Location GetLocationId(int id);
    }
}