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
        [HttpGet]
        [Route("api/Person")]
        public IEnumerable<Person> Get()
        {
            var repo = new PersonRepository();
            return repo.Get();
        }

        [HttpPost]
        [Route("api/Person/Create")]
        public Person Create(Person person)
        {
            var repo = new PersonRepository();
            return repo.Create(person);
        }

        [HttpDelete]
        [Route("api/Person/Delete")]
        public void Delete(int? Id)
        {
            var repo = new PersonRepository();
            repo.Delete(Id);
        }

        [HttpPut]
        [Route("api/Person/Update")]
        public void Update(int? Id, string email)
        {
            var repo = new PersonRepository();
            repo.Update(Id, email);
        }
    }
}
