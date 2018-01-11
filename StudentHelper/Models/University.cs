using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentHelper.Models
{
    public class University
    {
        public int UniversityId { get; set; }

        public string UniversityName { get; set; }

        public string Location { get; set; }

        public IEnumerable<Specialty> Specialties { get; set; }

        public string Site { get; set; }
    }
}