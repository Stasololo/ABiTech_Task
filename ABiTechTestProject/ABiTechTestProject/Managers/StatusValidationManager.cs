using ABiTechTestProject.Interface;
using ABiTechTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABiTechTestProject.Managers
{
    public class StatusValidationManager : IValidationManager<Status>
    {
        private readonly IRepository<Status> _repo;
        public StatusValidationManager(IRepository<Status> repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// метод, который проверяет на уникальность объект Status
        /// </summary>
        /// <param name="model">model - новый объект Status</param>
        /// <returns></returns>
        public bool CheckForUniqueByName(Status model)
        {
            if (_repo.Get().Any(x => x.Title == model.Title))
            {
                return false;
            }
            return true;
        }
    }
}