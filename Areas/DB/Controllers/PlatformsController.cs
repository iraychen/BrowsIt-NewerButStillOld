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
    public class PlatformsController : Controller
    {
        private BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();

        [HttpGet]
        public ActionResult Create()
        {
            PlatformCRUDModel model = new PlatformCRUDModel()
            {
                RequirementList = new SelectList(db.Requirements, "ID", "Title"),
                platform = new Platform(),
                message = ""
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlatformCRUDModel model)
        {
            // Bind selected item (will crash otherwise!)
            model.RequirementList = new SelectList(db.Requirements, "ID", "Title", model.myRequirement);

            if (ModelState.IsValid)
            {
                db.Platforms.Add(model.platform);
                db.SaveChanges();
                model.message = "Successfully added platform.";
                return View(model);
            }
            model.message = "Failed to add platform.";
            return View(model);
        }
    }
}
