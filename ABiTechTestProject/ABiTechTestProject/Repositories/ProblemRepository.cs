using ABiTechTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABiTechTestProject.Repositories
{
    public class ProblemRepository
    {
        public IEnumerable<Problem>Get()
        {
            var ctx = new ApplicationDbContext();
            return ctx.Problems;
        }

        public Problem Create(Problem problem)
        {
            var ctx = new ApplicationDbContext();
            var result = ctx.Problems.Add(problem);
            ctx.SaveChanges();
            return result;
        }

        public void Delete(int? Id)
        {
            var ctx = new ApplicationDbContext();
            var problem = ctx.Problems.Find(Id);
            ctx.Problems.Remove(problem);
            ctx.SaveChanges();
        }

        public void Update(int? Id, string name, string description, Status status, Person person)
        {
            var ctx = new ApplicationDbContext();
            var problem = ctx.Problems.Find(Id);
            problem.Name = name;
            problem.Description = description;
            problem.Status = status;
            problem.Person = person;
            ctx.SaveChanges();
        }
    }
}