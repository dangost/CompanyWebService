using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface ICountriesRepository
    {
        void Load();

        void Update();

        void Add(Country obj);

        void Edit(int id, Country obj);

        void DeleteCountry(int id);

        IEnumerable<Country> GetCountries();

        Country GetCountry(int id);
    }
}