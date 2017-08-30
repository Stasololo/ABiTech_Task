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
        
        /// <summary>
        /// метод показа списка бъектов Person
        /// </summary>
        /// <returns>возвращает список объектов Person</returns>
        public IEnumerable<Person> Get()
        {
            return _dbContext.Persons;
        }

        /// <summary>
        /// метод возвращающий объект Person по его id
        /// </summary>
        /// <param name="id">id - id объекта Person</param>
        /// <returns>возвращает объект Person</returns>
        public Person Get(int id)
        {
            return _dbContext.Persons.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// метод создания нового объекта Person
        /// </summary>
        /// <param name="person">person - объект Person</param>
        /// <returns>возвращает созданный объект Person</returns>
        public Person Create(Person person)
        {
            var result = _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();
            return result;
        }

        /// <summary>
        /// метод удаления объекта Person
        /// </summary>
        /// <param name="Id">Id - Id удаляемого объекта Person</param>
        public void Delete(int? Id)
        {
            var person = _dbContext.Persons.Find(Id);
            _dbContext.Persons.Remove(person);
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// метод изменения объект Person
        /// </summary>
        /// <param name="person">person - изменяемый объект Person</param>
        /// <returns>возвращает измененный объект Person</returns>
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