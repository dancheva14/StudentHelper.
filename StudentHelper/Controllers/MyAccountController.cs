using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentHelper.Services;

namespace StudentHelper.Controllers
{
    public class MyAccountController : Controller
    {
        PeopleService stService;

        public MyAccountController()
        {
            stService = new PeopleService();
        }
        public ActionResult MyAccount(int personId = 1)
        {
            var myAccount = stService.GetPersonById(personId);

            return View(myAccount);
        }
    }
}