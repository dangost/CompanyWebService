using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebService.Abstraction;
namespace WebService.Controllers
{
    public class HomeController : Controller
    {
        ICountriesRepository db;
        public HomeController(ICountriesRepository a)
        {
            db = a;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}