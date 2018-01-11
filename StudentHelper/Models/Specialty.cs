using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace StudentHelper.Models
{
    public class Specialty
    {
        public int SpecialtyId { get; set; }

        public string SpecialtyName { get; set; }

        public string Description { get; set; }

        public University University { get; set; }
    }
}