using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiEasyMissionWeb.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }
        public ActionResult Bid()
        {
            ViewBag.Title = "Bid";
            return View("Bid");
        }
    }
}