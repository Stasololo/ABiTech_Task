using ABiTechTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABiTechTestProject.Repositories
{
    public class PersonRepository
    {
        public IEnumerable<Person> Get()
        {
            var ctx = new ApplicationDbContext();
            return ctx.Persons;
        }

        public Person Create(Person person)
        {
            var ctx = new ApplicationDbContext();
            var result = ctx.Persons.Add(person);
            ctx.SaveChanges();
            return result;
        }

        public void Delete(int? Id)
        {
            var ctx = new ApplicationDbContext();
            var person = ctx.Persons.Find(Id);
            ctx.Persons.Remove(person);
            ctx.SaveChanges();
        }

        public void Update(int? Id, string email)
        {
            var ctx = new ApplicationDbContext();
            var person = ctx.Persons.Find(Id);
            person.Email = email;
            ctx.SaveChanges();
        }
    }
}