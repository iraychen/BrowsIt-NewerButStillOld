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
    public class TestScriptController : Controller
    {
        private BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();

        [HttpGet]
        public ActionResult Create()
        {
            TestScriptCRUDModel model = new TestScriptCRUDModel()
            {
                RequirementList = new SelectList(db.Requirements, "ID", "Title"),
                testScript = new TestScript(),
                message = ""
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestScriptCRUDModel model)
        {
            // Bind selected item (will crash otherwise!)
            model.RequirementList = new SelectList(db.Requirements, "ID", "Title", model.myRequirement);

            if (ModelState.IsValid)
            {
                db.TestScripts.Add(model.testScript);
                db.SaveChanges();
                model.message = "Successfully added testscript.";
                return View(model);
            }
            model.message = "Failed to add testscript.";
            return View(model);
        }
    }
}
