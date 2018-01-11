using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static StudentHelper.Enums.Enums;

namespace StudentHelper.Models
{
    public class Test
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public double Points { get; set; }

        public List<Question> Questions { get; set; }

        public Specialty Specialty { get; set; }

        public ExamsType ExamType{ get; set; }

        
    }
}