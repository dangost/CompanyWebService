using System.Collections.Generic;
using WebService.Models;

namespace WebService.Abstraction
{
    public interface IEmploymentJobsRepository
    {
        void Load();

        void Update();

        void Add(EmploymentJobs obj);

        void Edit(int id, EmploymentJobs obj);

        void DeleteCountry(int id);

        IEnumerable<EmploymentJobs> GetEmploymentJobs();

        EmploymentJobs GetEmploymentJobs(int id);
    }
}