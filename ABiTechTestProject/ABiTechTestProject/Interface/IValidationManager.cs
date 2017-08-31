using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABiTechTestProject.Interface
{
    public interface IValidationManager<T>
    {
        bool CheckForUniqueByName(T model);
    }
}
