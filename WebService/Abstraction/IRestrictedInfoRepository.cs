using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IRestrictedInfoRepository : IRepository<RestrictedInfo>
    {
        void DeleteRestrictedInfo(int id);

        IEnumerable<RestrictedInfo> GetRestrictedInfo();

        RestrictedInfo GetRestrictedInfoId(int id);
    }
}