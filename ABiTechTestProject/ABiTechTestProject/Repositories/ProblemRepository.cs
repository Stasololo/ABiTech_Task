using ABiTechTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABiTechTestProject.Repositories
{
    public class ProblemRepository
    {
        public IEnumerable<Problem>GetProblem()
        {
            var ctx = new ApplicationDbContext();
            return ctx.Problems;
        }

        public Problem CreateProblem(Problem problem)
        {
            var ctx = new ApplicationDbContext();
            var result = ctx.Problems.Add(problem);
            ctx.SaveChanges();
            return result;
        }

        public void DeleteProblem(int? Id)
        {
            var ctx = new ApplicationDbContext();
            var problem = ctx.Problems.Find(Id);
            ctx.Problems.Remove(problem);
            ctx.SaveChanges();
        }

        public void UpdateProblem(Problem problem)
        {
            var ctx = new ApplicationDbContext();
            
        }
    }
}