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
    public class RoundController : Controller
    {
        private GolfStatTrackerEntities db = new GolfStatTrackerEntities();

        //
        // GET: /Round/

        public ActionResult Index()
        {
            return View(db.Rounds.ToList());
        }

        //
        // GET: /Round/Details/5

        public ActionResult Details(int id = 0)
        {
            Round round = db.Rounds.Find(id);
            if (round == null)
            {
                return HttpNotFound();
            }
            return View(round);
        }

        //
        // GET: /Round/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Round/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Round round)
        {
            if (ModelState.IsValid)
            {
                db.Rounds.Add(round);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(round);
        }

        //
        // GET: /Round/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Round round = db.Rounds.Find(id);
            if (round == null)
            {
                return HttpNotFound();
            }
            return View(round);
        }

        //
        // POST: /Round/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Round round)
        {
            if (ModelState.IsValid)
            {
                db.Entry(round).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(round);
        }

        //
        // GET: /Round/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Round round = db.Rounds.Find(id);
            if (round == null)
            {
                return HttpNotFound();
            }
            return View(round);
        }

        //
        // POST: /Round/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Round round = db.Rounds.Find(id);
            db.Rounds.Remove(round);
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