using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentHelper.Enums
{
    public class Enums
    {
        public enum Education
        {
            [Display(Name = "Основно образование")]
            primary = 0,
            [Display(Name = "Средно образование")]
            secondary = 1,
            [Display(Name = "Висше образование")]
            higher = 2,
            [Display(Name = "Магистър")]
            master = 3,
            [Display(Name = "Професор")]
            professor = 4
        }

        public enum PType
        {
            [Display(Name = "Студент")]
            student = 0,
            [Display(Name = "Преподавател")]
            teacher = 1
        }

        public enum ExamsType
        {
            [Display(Name = "Изпит")]
            exam = 0,
            [Display(Name = "Контролно")]
            test = 1
        }
    }
}