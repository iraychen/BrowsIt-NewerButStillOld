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
    public class RequirementsController : Controller
    {
        private BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();

        [HttpGet]
        public ActionResult Create()
        {
            RequirementCRUDModel model = new RequirementCRUDModel()
            {
                TargetList = new SelectList(db.Targets, "ID", "Name"),
                requirement = new Requirement(),
                message = ""
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RequirementCRUDModel model)
        {
            // Bind selected item (will crash otherwise!)
            model.TargetList = new SelectList(db.Targets, "ID", "Name", model.myTarget);

            if (ModelState.IsValid)
            {
                db.Requirements.Add(model.requirement);
                db.SaveChanges();
                model.message = "Successfully added requirement.";
                return View(model);
            }
            model.message = "Failed to add requirement.";
            return View(model);
        }
    }
}
