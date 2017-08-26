using ABiTechTestProject.Models;
using ABiTechTestProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ABiTechTestProject.Controllers
{
    public class ProblemAPIController : ApiController
    {
        [HttpGet]
        [Route("api/Problem")]
        public IEnumerable<Problem> Get()
        {
            var repo = new ProblemRepository();
            return repo.Get();
        }

        [HttpPost]
        [Route("api/Problem/Create")]
        public Problem Create(Problem problem)
        {
            var repo = new ProblemRepository();
            return repo.Create(problem);
        }

        [HttpDelete]
        [Route("api/Problem/Delete")]
        public void Delete(int? Id)
        {
            var repo = new ProblemRepository();
            repo.Delete(Id);
        }

        [HttpPut]
        [Route("api/Problem/Update")]
        public void Update(int? Id, string name, string description, Status status, Person person)
        {
            var repo = new ProblemRepository();
            repo.Update(Id, name, description, status, person);
        }
    }
}
