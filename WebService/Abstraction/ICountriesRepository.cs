using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface ICountriesRepository : IRepository<Country>
    {
        void DeleteCountry(int id);

        IEnumerable<Country> GetCountries();

        Country GetCountryId(int id);
    }
}