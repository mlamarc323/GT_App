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
    public class CourseController : Controller
    {
        private GolfStatTrackerEntities db = new GolfStatTrackerEntities();
        SessionObj session = new SessionObj();

        //
        // GET: /Course/

        public ActionResult Index()
        {
            var prevView = System.Web.HttpContext.Current.Request.UrlReferrer;
            var courses = db.Courses.Include(c => c.Facility);
            
            // Clears Session if creation of all relevent entities is stopped
            if (prevView.AbsolutePath == "/Course/Create")
            {
                Session["FacilityId"] = 0;
                Session["FacilityName"] = string.Empty;
                Session["CourseId"] = 0;
                Session["CourseName"] = string.Empty;
            }
            return View(courses.ToList());
        }


        //
        // GET: /Course/Details/5

        public ActionResult Details(int id = 0)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        //
        // GET: /Course/Create

        public ActionResult Create()
        {
            ViewBag.FacilityId = new SelectList(db.Facilities, "FacilityId", "Name");
            return View();
        }

        //
        // POST: /Course/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                if (Session["FacilityId"] != null || Convert.ToInt32(Session["FacilityId"]) != 0)
                {
                    course.FacilityId = Convert.ToInt32(Session["FacilityId"]);
                }
                Session["FacilityId"] = course.FacilityId;
                Session["FacilityName"] = course.Name;
                Session["CourseId"] = course.CourseId;
                Session["CourseName"] = course.Name;
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Create", "Hole");
            }

            ViewBag.FacilityId = new SelectList(db.Facilities, "FacilityId", "Name", course.FacilityId);
            return View(course);
        }

        //
        // GET: /Course/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            Session["FacilityId"] = course.FacilityId;
            Session["CourseId"] = course.CourseId;
            ViewBag.FacilityId = new SelectList(db.Facilities, "FacilityId", "Name", course.FacilityId);
            return View(course);
        }

        //
        // POST: /Course/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                Session["FacilityId"] = course.FacilityId;
                Session["CourseId"] = course.CourseId;
                return RedirectToAction("Index");
            }
            ViewBag.FacilityId = new SelectList(db.Facilities, "FacilityId", "Name", course.FacilityId);
            return View(course);
        }

        //
        // GET: /Course/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            Session["FacilityId"] = course.FacilityId;
            Session["CourseId"] = course.CourseId;
            return View(course);
        }

        //
        // POST: /Course/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            Session["FacilityId"] = course.FacilityId;
            Session["CourseId"] = course.CourseId;
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}