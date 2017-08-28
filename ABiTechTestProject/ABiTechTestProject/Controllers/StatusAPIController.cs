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
    public class StatusAPIController : ApiController
    {
        [HttpGet]
        [Route("api/StatusAPI")]
        public IEnumerable<Status> Get()
        {
            var repo = new StatusRepository();
            return repo.Get();
        }

        [HttpPost]
        [Route("api/StatusAPI/Create")]
        public Status Create(Status status)
        {
            var repo = new StatusRepository();
            return repo.Create(status);
        }

        [HttpDelete]
        [Route("api/StatusAPI/Delete")]
        public void Delete(int? Id)
        {
            var repo = new StatusRepository();
            repo.Delete(Id);
        }

        [HttpPut]
        [Route("api/StatusAPI/Update")]
        public void Update(int? Id, string title)
        {
            var repo = new StatusRepository();
            repo.Update(Id, title);
        }
    }
}
