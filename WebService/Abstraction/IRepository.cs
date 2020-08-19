using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Abstraction
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        void Load();

        void Update();

        void Add(T obj);

        void Edit(int id, T obj);
    }
}
