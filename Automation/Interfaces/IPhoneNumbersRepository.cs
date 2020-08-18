using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IPhoneNumbersRepository
    {
        void Load();

        void Update();

        void Add(PhoneNumber obj);

        void Edit(int id, PhoneNumber obj);

        void DeleteCountry(int id);

        IEnumerable<PhoneNumber> GetPhoneNumbers();

        PhoneNumber GetPhoneNumber(int id);
    }
}