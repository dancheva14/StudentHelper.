using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentHelper.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public bool IsChecked { get; set; }

        public Question Question { get; set; }
    }
}