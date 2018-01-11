using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentHelper.Models;
using StudentHelper.Services;

namespace StudentHelper.Controllers
{
    public class UniversitiesController : Controller
    {
        UniversityService universityService;

        public UniversitiesController()
        {
            universityService = new UniversityService();
        }

        public ActionResult UniversitiesMainView()
        {
            var universities = universityService.GetAllUniversities();
            return View(universities);
        }

        public ActionResult UniversityInformationView(int universityId = 1)
        {
            var university = universityService.GetUniversity(universityId);
            return View(university);
        }

        [HttpGet]
        public ActionResult InsertUniversity()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertUniversity(University university)
        {
            universityService.InsertUniversity(university);
            return View();
        }
    }
}