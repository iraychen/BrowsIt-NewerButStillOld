using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BROWSit.Models;
using BROWSit.Helpers;
using BROWSit.Helpers.SqlHelper;

namespace BROWSit.Areas.DB.Controllers
{
    public class RoleController : Controller
    {
        private BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();

        [HttpGet]
        public ActionResult Create(string message = "")
        {
            RoleCRUDModel model = new RoleCRUDModel(message);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Create", new { @message = "Successfully added role." });
            }
            return RedirectToAction("Create", new { @message = "Failed to add role." });
        }
    }
}
