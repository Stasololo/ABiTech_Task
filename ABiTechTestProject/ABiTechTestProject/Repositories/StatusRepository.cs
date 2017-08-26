using ABiTechTestProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABiTechTestProject.Repositories
{
    public class StatusRepository
    {
        public IEnumerable<Status> Get()
        {
            var ctx = new ApplicationDbContext();
            return ctx.Statuses;
        }

        public Status Create(Status status)
        {
            var ctx = new ApplicationDbContext();
            var result = ctx.Statuses.Add(status);
            ctx.SaveChanges();
            return result;
        }

        public void Delete(int? Id)
        {
            var ctx = new ApplicationDbContext();
            var status = ctx.Statuses.Find(Id);
            ctx.Statuses.Remove(status);
            ctx.SaveChanges();
        }

        public void Update(int? Id, string title)
        {
            var ctx = new ApplicationDbContext();
            var status = ctx.Statuses.Find(Id);
            status.Title = title;
            ctx.SaveChanges();
        }
    }
}