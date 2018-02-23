using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PersonViewer()
        {
            ViewBag.Name = "Alex Houston";
            ViewBag.Address = "123 street";

            return View();
        }
    }
}