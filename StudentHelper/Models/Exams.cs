using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static StudentHelper.Enums.Enums;

namespace StudentHelper.Models
{
    public class Exams
    {
        public int ExamsId { get; set; }

        public Specialty Specialty { get; set; }

        public ExamsType ExamType{ get; set; }

        public DateTime? ExamDate { get; set; }

        public string Hall { get; set; }
    }
}