using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IEmploymentJobsRepository : IRepository<EmploymentJobs>
    {
        void DeleteEmploymentJobs(int id);

        IEnumerable<EmploymentJobs> GetEmploymentJobs();

        EmploymentJobs GetEmploymentJobsId(int id);
    }
}