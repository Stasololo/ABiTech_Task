using ABiTechTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABiTechTestProject.Repositories
{
    public class PersonRepository : IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        public IEnumerable<Person> Get()
        {
            return _dbContext.Persons;
        }

        public Person Get(int id)
        {
            return _dbContext.Persons.FirstOrDefault(x => x.Id == id);
        }

        public Person Create(Person person)
        {
            var result = _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();
            return result;
        }

        public void Delete(int? Id)
        {
            var person = _dbContext.Persons.Find(Id);
            _dbContext.Persons.Remove(person);
            _dbContext.SaveChanges();
        }

        public void Update(Person model)
        {
            var person = _dbContext.Persons.Find(model.Id);
            person.Email = model.Email;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}