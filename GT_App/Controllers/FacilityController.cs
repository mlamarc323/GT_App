using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GT_App.Models;

namespace GT_App.Controllers
{
    public class FacilityController : Controller
    {
        private GolfStatTrackerEntities db = new GolfStatTrackerEntities();
        //private SessionObj session = new SessionObj();

        //
        // GET: /Facility/

        public ActionResult Index()
        {
            return View(db.Facilities.ToList());
        }

        //
        // GET: /Facility/Details/5

        public ActionResult Details(int id = 0)
        {
            Facility facility = db.Facilities.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            return View(facility);
        }

        //
        // GET: /Facility/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Facility/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Facility facility)
        {
            if (ModelState.IsValid)
            {
                db.Facilities.Add(facility);
                db.SaveChanges();
                Session["FacilityId"] = facility.FacilityId;
                Session["FacilityName"] = facility.Name;
                return RedirectToAction("Create", "Course");
            }

            return View();
        }

        //
        // GET: /Facility/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Facility facility = db.Facilities.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            Session["FacilityId"] = facility.FacilityId;
            return View(facility);
        }

        //
        // POST: /Facility/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Facility facility)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facility).State = EntityState.Modified;
                db.SaveChanges();
                Session["FacilityId"] = string.Empty;
                return RedirectToAction("Index");
            }
            return View(facility);
        }

        //
        // GET: /Facility/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Facility facility = db.Facilities.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            Session["FacilityId"] = facility.FacilityId;
            return View(facility);
        }

        //
        // POST: /Facility/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facility facility = db.Facilities.Find(id);
            db.Facilities.Remove(facility);
            db.SaveChanges();
            Session["FacilityId"] = string.Empty;
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}