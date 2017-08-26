using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ABiTechTestProject.Models
{
    public class Problem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public Status Status { get; set; }
        public Person Person { get; set; }
    }
}