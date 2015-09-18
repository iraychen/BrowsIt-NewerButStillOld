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
    public class FeaturesController : Controller
    {
        private BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();

        [HttpGet]
        public ActionResult Create()
        {
            FeatureCRUDModel model = new FeatureCRUDModel()
            {
                feature = new Feature(),
                message = ""
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeatureCRUDModel model)
        {
            if (ModelState.IsValid)
            {
                db.Features.Add(model.feature);
                db.SaveChanges();
                model.message = "Successfully added feature.";
                return View(model);
            }
            model.message = "Failed to add feature.";
            return View(model);
        }
    }
}
