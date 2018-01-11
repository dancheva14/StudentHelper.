using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentHelper.Models;

namespace StudentHelper.ViewModels
{
    public class MultipleViewModel
    {
        public Person Person { get; set; }

        public IEnumerable<University> Universities { get; set; }

        public IEnumerable<Specialty> Specialties { get; set; }

        public Specialty Specialty { get; set; }
    }
}