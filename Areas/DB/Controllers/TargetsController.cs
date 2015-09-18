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
    public class TargetsController : Controller
    {
        private BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();

        [HttpGet]
        public ActionResult Create()
        {
            TargetCRUDModel model = new TargetCRUDModel()
            {
                target = new Target(),
                message = ""
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TargetCRUDModel model)
        {
            if (ModelState.IsValid)
            {
                db.Targets.Add(model.target);
                db.SaveChanges();
                model.message = "Successfully added target.";
                return View(model);
            }
            model.message = "Failed to add target.";
            return View(model);
        }
    }
}
