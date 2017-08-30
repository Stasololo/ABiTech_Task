using ABiTechTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABiTechTestProject.Repositories
{
    public class StatusRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StatusRepository()
        {
            _dbContext = new ApplicationDbContext();
        }

        /// <summary>
        /// метод показа списка объектов Status
        /// </summary>
        /// <returns>возвращает список объектов Status</returns>
        public IEnumerable<Status> Get()
        {
            return _dbContext.Statuses;
        }

        /// <summary>
        /// метод возвращающий объект Status по его id
        /// </summary>
        /// <param name="id">id - id объекта Status</param>
        /// <returns>возвращает объект Status</returns>
        public Status Get(int id)
        {
            return _dbContext.Statuses.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// метод создания нового объект Status
        /// </summary>
        /// <param name="status">status - объект Status</param>
        /// <returns>возвращает созданный объект Status</returns>
        public Status Create(Status status)
        {
            var result = _dbContext.Statuses.Add(status);
            _dbContext.SaveChanges();
            return result;
        }

        /// <summary>
        /// метод удаления Status
        /// </summary>
        /// <param name="Id">Id - Id удаляемого объекта Status</param>
        public void Delete(int? Id)
        {
            var status = _dbContext.Statuses.Find(Id);
            _dbContext.Statuses.Remove(status);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// метод изменения объекта Status
        /// </summary>
        /// <param name="status">status - изменяемый объект Status</param>
        /// <returns>возвращает измененный объект Status</returns>
        public void Update(Status model)
        {
            var status = _dbContext.Statuses.Find(model.Id);
            status.Title = model.Title;
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}