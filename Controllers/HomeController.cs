using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.Reflection.Emit;
using BROWSit.Models;
using BROWSit.Helpers;

namespace BROWSit.Controllers
{
    public class HomeController : Controller
    {
        BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About";
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Documentation()
        {
            ViewBag.Title = "Documentation";
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
