using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IRestrictedInfoRepository
    {
        void Load();

        void Update();

        void Add(RestrictedInfo obj);

        void Edit(int id, RestrictedInfo obj);

        void DeleteCountry(int id);

        IEnumerable<RestrictedInfo> GetRestrictedInfo();

        RestrictedInfo GetRestrictedInfo(int id);
    }
}