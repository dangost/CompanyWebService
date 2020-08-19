using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IPhoneNumbersRepository : IRepository<PhoneNumber>
    {
        void DeletePhoneNumber(int id);

        IEnumerable<PhoneNumber> GetPhoneNumbers();

        PhoneNumber GetPhoneNumberId(int id);
    }
}