using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static StudentHelper.Enums.Enums;

namespace StudentHelper.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        public string PersonName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PersonInformation { get; set; }

        public Education EducationType { get; set; }

        public PType Type { get; set; }

        public University University { get; set; }

        public List<Specialty> Specialties { get; set; }
    }
}