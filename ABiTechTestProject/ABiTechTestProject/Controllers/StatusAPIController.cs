using ABiTechTestProject.Interface;
using ABiTechTestProject.Managers;
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
        private readonly StatusRepository _repo;
        private readonly IValidationManager<Status> _validationMngr;

        public StatusAPIController()
        {
            _repo = new StatusRepository();
            _validationMngr = new StatusValidationManager(_repo);
        }

        [HttpGet]
        [Route("api/StatusAPI")]
        public IEnumerable<Status> Get()
        {
            return _repo.Get();
        }
        
        [HttpPost]
        [Route("api/StatusAPI/Create")]
        public Status Create(Status status)
        {
            if (_validationMngr.CheckForUniqueByName(status))
            {
                return _repo.Create(status);
            }
            else
            {
                throw new Exception("Status with this name is already exist");
            }            
        }
        
        [HttpDelete]
        [Route("api/StatusAPI/Delete/{Id:int}")]
        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        [HttpPut]
        [Route("api/StatusAPI/Update")]
        public Status Update(Status status)
        {
            _repo.Update(status);
            return _repo.Get(status.Id);
        }
    }
}
