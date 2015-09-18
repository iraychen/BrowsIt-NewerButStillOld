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
    public class SRSController : Controller
    {
        private BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();

        [HttpGet]
        public ActionResult Create(string message = "")
        {
            SRSCRUDModel model = new SRSCRUDModel(message);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SRSCRUDModel model)
        {
            if (ModelState.IsValid)
            {
                if (!String.IsNullOrEmpty(model.submitType))
                {
                    if (model.submitType == "create")
                    {
                        if (!String.IsNullOrEmpty(model.srs.Filename))
                        {
                            // Export the model to OpenXML Word Document
                            WordHelper.exportToWord(model);

                            // Save SRS entity to Database
                            BROWSit.DAL.BROWSitContext db = new BROWSit.DAL.BROWSitContext();
                            db.SRS.Add(model.srs);
                            db.SaveChanges();
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(model.add))
                    {
                        if (model.add == "area")
                        {
                            if (model.areaNames != null)
                            {
                                model.areaNames.Add("New Area");
                                model.mappings.Add(0);
                            }
                        }
                        else
                        {
                            if (model.requirementNames != null)
                            {
                                model.requirementNames.Add("New Requirement Name");
                                model.requirementDescriptions.Add("New Requirement Description");
                                model.mappings[Int32.Parse(model.add)]++;
                            }
                        }
                    }
                }
            }

            return View(model);
        }

        /*{
            if (ModelState.IsValid)
            {
                db.SRS.Add(srs);
                db.SaveChanges();
                return RedirectToAction("Create", new { @message = "Successfully added SRS." });
            }
            return RedirectToAction("Create", new { @message = "Failed to add SRS." });
        }*/
    }
}
