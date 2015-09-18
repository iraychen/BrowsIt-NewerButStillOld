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
        public ActionResult Create(string message = "")
        {
            RequirementDBModel model = new RequirementDBModel(message);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Requirement requirement)
        {
            if (ModelState.IsValid)
            {
                db.Requirements.Add(requirement);
                db.SaveChanges();
                return RedirectToAction("Create", new { @message = "Successfully added requirement." });
            }
            return RedirectToAction("Create", new { @message = "Failed to add requirement." });
        }
    }

    public class PlatformsController : Controller
    {
        private BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();

        [HttpGet]
        public ActionResult Create(string message = "")
        {
            PlatformDBModel model = new PlatformDBModel(message);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Platform platform)
        {
            if (ModelState.IsValid)
            {
                db.Platforms.Add(platform);
                db.SaveChanges();
                return RedirectToAction("Create", new { @message = "Successfully added platform." });
            }
            return RedirectToAction("Create", new { @message = "Failed to add platform." });
        }
    }

    public class TargetsController : Controller
    {
        private BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();

        [HttpGet]
        public ActionResult Create(string message = "")
        {
            TargetDBModel model = new TargetDBModel(message);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Target target)
        {
            if (ModelState.IsValid)
            {
                db.Targets.Add(target);
                db.SaveChanges();
                return RedirectToAction("Create", new { @message = "Successfully added target." });
            }
            return RedirectToAction("Create", new { @message = "Failed to add target." });
        }
    }

    public class FeaturesController : Controller
    {
        private BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();

        [HttpGet]
        public ActionResult Create(string message = "")
        {
            FeatureDBModel model = new FeatureDBModel(message);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Feature feature)
        {
            if (ModelState.IsValid)
            {
                db.Features.Add(feature);
                db.SaveChanges();
                return RedirectToAction("Create", new { @message = "Successfully added feature." });
            }
            return RedirectToAction("Create", new { @message = "Failed to add feature." });
        }
    }
}
