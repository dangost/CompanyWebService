using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IEmploymentsRepository
    {
        void Load();

        void Update();

        void Add(Employment obj);

        void Edit(int id, Employment obj);

        void DeleteCountry(int id);

        IEnumerable<Employment> GetEmployments();

        Employment GetEmployment(int id);
    }
}