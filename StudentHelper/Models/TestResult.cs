using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace StudentHelper.Models
{
    public class TestResult
    {
        public int TestResultId { get; set; }

        public int CorrectAnswers { get; set; }

        public int WrongAnswers { get; set; }

        public int EmptyAnswers { get; set; }

        public int Procent { get; set; }

        public string Status { get; set; }

        public Test Test { get; set; }

        public Person Person { get; set; }

        public string Grade { get; set; }

        public DateTime Date { get; set; }
        
    }
}