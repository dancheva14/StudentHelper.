using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace StudentHelper.Models
{
    public class Grade
    {
        public int GradeId { get; set; }

        public Person Person { get; set; }

        public Specialty Specialty { get; set; }

        public int GradeN { get; set; }

        public string GradeName { get; set; }
    }
}