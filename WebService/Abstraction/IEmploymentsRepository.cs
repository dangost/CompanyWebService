using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IEmploymentsRepository : IRepository<Employment>
    {
        void DeleteEmployment(int id);

        IEnumerable<Employment> GetEmployments();

        Employment GetEmploymentId(int id);
    }
}