using ABiTechTestProject.Models;
using ABiTechTestProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABiTechTestProject.Repositories
{
    public class ProblemRepository : IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public ProblemRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        /// <summary>
        /// метод показа списка объектов Problem
        /// </summary>
        /// <returns>возвращает список объектов Problem</returns>
        public IEnumerable<Problem>Get()
        {
            return _dbContext.Problems.Include("Status").Include("Person");
        }

        /// <summary>
        /// метод возвращающий объект Problem по его id
        /// </summary>
        /// <param name="id">id - id объекта Problem</param>
        /// <returns>возвращает объект Problem</returns>
        public Problem Get(int id)
        {
            return _dbContext.Problems.Include("Status").Include("Person").FirstOrDefault(x=> x.Id == id);
        }

        /// <summary>
        /// мектод создания нового объекта Problem
        /// </summary>
        /// <param name="problem"></param>
        /// <returns>возвращает созданный объект Problem</returns>
        public Problem Create(Problem problem)
        {
            var status = _dbContext.Statuses.Find(problem.Status.Id);
            var person = _dbContext.Persons.Find(problem.Person.Id);
            problem.Status = status;
            problem.Person = person;
            var result = _dbContext.Problems.Add(problem);
            _dbContext.SaveChanges();
            return result;
        }

        /// <summary>
        /// метод удаления объекта Problem
        /// </summary>
        /// <param name="Id">Id - Id удаляемого объекта Problem</param>
        public void Delete(int? Id)
        {
            var problem = _dbContext.Problems.Find(Id);
            _dbContext.Problems.Remove(problem);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// метод изменения объекта Problem
        /// </summary>
        /// <param name="model">model - изменяемый объект Problem</param>
        /// <returns>возвращает измененный объект Problem</returns>
        public void Update(ProblemUpdateVM model)
        {
            var problem = _dbContext.Problems.Find(model.Id);

            problem.Name = model.Name;
            problem.Description = model.Description;
            problem.StatusId = model.StatusId;
            problem.PersonId = model.PersonId;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}