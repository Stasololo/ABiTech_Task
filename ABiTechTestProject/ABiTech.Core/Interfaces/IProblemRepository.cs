using ABiTechTestProject.Models;
using ABiTechTestProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABiTechTestProject.Interface
{
    public interface IProblemRepository : IRepository<Problem>
    {
        void Update(ProblemUpdateVM model);
    }
}
