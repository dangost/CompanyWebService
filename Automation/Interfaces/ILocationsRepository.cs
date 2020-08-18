using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface ILocationsRepository
    {
        void Load();

        void Update();

        void Add(Location obj);

        void Edit(int id, Location obj);

        void DeleteCountry(int id);

        IEnumerable<Location> GetLocations();

        Location GetLocation(int id);
    }
}