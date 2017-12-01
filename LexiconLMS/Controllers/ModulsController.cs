using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LexiconLMS.Models;

namespace LexiconLMS.Controllers
{
    public class ModulsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Moduls
        public ActionResult Index()
        {
            var moduls = db.Moduls.Include(m => m.Course);
            return View(moduls.ToList());
        }

        // GET: Moduls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.ModulActivities = db.Activities.Where(p => p.ModuleId == id).ToList();
            Modul modul = db.Moduls.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            return View(modul);
        }

        // GET: Moduls/Create
        public ActionResult Create()
        {
            ViewBag.Courseid = new SelectList(db.Courses, "CourseId", "CourseName");
            return PartialView();
        }

        // POST: Moduls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ModulName,ModulDescription,ModulStart,ModulEnd,Courseid")] Modul modul)
        {
            if (ModelState.IsValid)
            {
                db.Moduls.Add(modul);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Courseid = new SelectList(db.Courses, "CourseId", "CourseName", modul.Courseid);
            return PartialView(modul);
        }

        // GET: Moduls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Moduls.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            ViewBag.Courseid = new SelectList(db.Courses, "CourseId", "CourseName", modul.Courseid);
            return View(modul);
        }

        // POST: Moduls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ModulName,ModulDescription,ModulStart,ModulEnd,Courseid")] Modul modul)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Courseid = new SelectList(db.Courses, "CourseId", "CourseName", modul.Courseid);
            return View(modul);
        }

        // GET: Moduls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Moduls.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            return View(modul);
        }

        // POST: Moduls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modul modul = db.Moduls.Find(id);
            db.Moduls.Remove(modul);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
