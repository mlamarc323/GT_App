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
    public class GolferController : Controller
    {
        private GT_AppDBEntities2 db = new GT_AppDBEntities2();

        //
        // GET: /Golfer/

        public ActionResult Index()
        {
            return View(db.Golfers.ToList());
        }

        //
        // GET: /Golfer/Details/5

        public ActionResult Details(int id = 0)
        {
            Golfer golfer = db.Golfers.Find(id);
            if (golfer == null)
            {
                return HttpNotFound();
            }
            return View(golfer);
        }

        //
        // GET: /Golfer/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Golfer/Create

        [HttpPost]
        public ActionResult Create(Golfer golfer)
        {
            if (ModelState.IsValid)
            {
                db.Golfers.Add(golfer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(golfer);
        }

        //
        // GET: /Golfer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Golfer golfer = db.Golfers.Find(id);
            if (golfer == null)
            {
                return HttpNotFound();
            }
            return View(golfer);
        }

        //
        // POST: /Golfer/Edit/5

        [HttpPost]
        public ActionResult Edit(Golfer golfer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(golfer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(golfer);
        }

        //
        // GET: /Golfer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Golfer golfer = db.Golfers.Find(id);
            if (golfer == null)
            {
                return HttpNotFound();
            }
            return View(golfer);
        }

        //
        // POST: /Golfer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Golfer golfer = db.Golfers.Find(id);
            db.Golfers.Remove(golfer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}