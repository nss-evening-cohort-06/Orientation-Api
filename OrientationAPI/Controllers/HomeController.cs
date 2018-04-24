using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OrientationAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Employees()
        {
            ViewBag.Title = "Employees";

            return View();
        }

        public ActionResult Departments()
        {
            ViewBag.Title = "Departments";

            return View();
        }

        public ActionResult Computers()
        {
            ViewBag.Title = "Computers";

            return View();
        }

        public ActionResult TrainingPrograms()
        {
            ViewBag.Title = "Training Programs";

            return View();
        }

    }
}