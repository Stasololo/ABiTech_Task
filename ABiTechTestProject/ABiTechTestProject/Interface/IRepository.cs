using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABiTechTestProject.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();

        T Get(int Id);

        T Create(T model);

        void Delete(int Id);

        void Update(T model);
    }
}
