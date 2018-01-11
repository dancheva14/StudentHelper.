using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentHelper.Services;
using StudentHelper.ViewModels;

namespace StudentHelper.Controllers
{
    public class SpecialtiesController : Controller
    {
        SpecialtyService specialtyService;
        UniversityService unServise;

        public SpecialtiesController()
        {
            specialtyService = new SpecialtyService();
            unServise = new UniversityService();
        }

        public ActionResult SpecialtyMainView()
        {
            var specialties = specialtyService.GetAllSpecialties();
            return View(specialties);
        }

        public ActionResult SpecialtyInformationView(int specialtyId = 1)
        {
            var specialty = specialtyService.GetSpecialty(specialtyId);
            return View(specialty);
        }

        [HttpGet]
        public ActionResult InsertSpecialty()
        {
            MultipleViewModel multipleViewModel = new MultipleViewModel();
            multipleViewModel.Universities = unServise.GetAllUniversities();
            return View(multipleViewModel);
        }

        [HttpPost]
        public ActionResult InsertSpecialty(MultipleViewModel multipleViewModel)
        {
            specialtyService.InsertSpecialty(multipleViewModel);
            return View("Specialties", "SpecialtiesMainView");
        }
    }
}