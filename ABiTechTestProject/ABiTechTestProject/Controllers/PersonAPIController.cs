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
    public class PersonAPIController : ApiController
    {
        private readonly PersonRepository _repo;

        public PersonAPIController()
        {
            _repo = new PersonRepository();
        }
        [HttpGet]
        [Route("api/PersonAPI")]
        public IEnumerable<Person> Get()
        {
            return _repo.Get();
        }

        [HttpPost]
        [Route("api/PersonAPI/Create")]
        public Person Create(Person person)
        {
            return _repo.Create(person);
        }

        [HttpDelete]
        [Route("api/PersonAPI/Delete")]
        public void Delete(int? Id)
        {
            _repo.Delete(Id);
        }

        [HttpPut]
        [Route("api/PersonAPI/Update")]
        public Person Update(Person model)
        {
            _repo.Update(model);
            return _repo.Get(model.Id);
        }
    }
}
