using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABiTechTestProject.ViewModel
{
    public class ProblemUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int PersonId { get; set; }
    }
}