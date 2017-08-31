using ABiTechTestProject.Models;
using ABiTechTestProject.Repositories;
using ABiTechTestProject.ViewModel;
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
        private readonly ProblemRepository _repo;
        public ProblemAPIController()
        {
            _repo = new ProblemRepository();
        }

        [HttpGet]
        [Route("api/ProblemAPI")]
        public IEnumerable<Problem> Get()
        {            
            return _repo.Get();
        }

        [HttpPost]
        [Route("api/ProblemAPI/Create")]
        public Problem Create(Problem problem)
        {
            return _repo.Create(problem);
        }

        [HttpDelete]
        [Route("api/ProblemAPI/Delete/{Id:int}")]
        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        [HttpPut]
        [Route("api/ProblemAPI/Update")]
        public Problem Update(ProblemUpdateVM model)
        {
            _repo.Update(model);
            return _repo.Get(model.Id);
        }

        public new void Dispose()
        {
            _repo.Dispose();
        }
    }
}
