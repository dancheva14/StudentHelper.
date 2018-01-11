using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentHelper.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Comment { get; set; }

        public int Answer { get; set; }

        public List<Answer> Answers { get; set; }

        public int? RightAnswerIndex { get; set; }

        public Test Test { get; set; }
    }
}