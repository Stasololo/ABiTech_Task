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
        [Route("api/Status")]
        public IEnumerable<Status> Get()
        {
            var repo = new StatusRepository();
            return repo.Get();
        }

        [HttpPost]
        [Route("api/Status/Create")]
        public Status Create(Status status)
        {
            var repo = new StatusRepository();
            return repo.Create(status);
        }

        [HttpDelete]
        [Route("api/Status/Delete")]
        public void Delete(int? Id)
        {
            var repo = new StatusRepository();
            repo.Delete(Id);
        }

        [HttpPut]
        [Route("api/Status/Update")]
        public void Update(int? Id, string title)
        {
            var repo = new StatusRepository();
            repo.Update(Id, title);
        }
    }
}
