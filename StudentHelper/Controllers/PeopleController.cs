using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentHelper.Models;
using StudentHelper.Services;
using System.Web.Mvc.Html;
using StudentHelper.ViewModels;

namespace StudentHelper.Controllers
{
    public class PeopleController : Controller
    {
        PeopleService stService;
        UniversityService unServise;
        public PeopleController()
        {
            stService = new PeopleService();
            unServise = new UniversityService();
        }

        public ActionResult PeopleMainView()
        {
            return View(stService.GetAllPeople());
        }

        public ActionResult PersonInformationView(int personId = 10)
        {
            var student = stService.GetPersonById(personId);
            return View(student);
        }

        [HttpGet]
        public ActionResult InsertPerson()
        {
            MultipleViewModel multipleViewModel = new MultipleViewModel();
            multipleViewModel.Universities = unServise.GetAllUniversities();
            return View(multipleViewModel);
        }

        [HttpPost]
        public ActionResult InsertPerson(MultipleViewModel multipleViewModel)
        {            
            stService.InsertPerson(multipleViewModel);
            return View("People", "PeopleMainView");
        }
    }
}