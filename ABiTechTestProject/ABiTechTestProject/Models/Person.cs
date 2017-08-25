using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABiTechTestProject.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
    }
}