using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LexiconLMS.Models;
using System.IO;
using Microsoft.AspNet.Identity;

namespace LexiconLMS.Controllers
{
    public class ActivitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult UploadIndex(HttpPostedFileBase postedFile)
        {
            foreach (string upload in Request.Files)
            {
            
                if (Request.Files[upload].FileName != "")
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "/uploads/";
                    string filename = Path.GetFileName(Request.Files[upload].FileName);
                    Request.Files[upload].SaveAs(Path.Combine(path, filename));
                    int documentTypeId = Convert.ToInt32(HttpContext.Request.Params["documentTypeId"]);
                    int activityId = Convert.ToInt32(HttpContext.Request.Params["activityId"]);
                    db.Documents.Add(new Document {
                        Name = filename,
                        TimeStamp = DateTime.Now,
                        FileName = filename,
                        DocumentTypeId = documentTypeId,
                        ActivityId = activityId,
                        UserId = User.Identity.GetUserId()

                });

                    db.SaveChanges();

                }
            }
            return View();
        }

        public ActionResult Downloads()
        {
            var dir = new DirectoryInfo(Server.MapPath("~/uploads/"));
            FileInfo[] fileNames = dir.GetFiles("*.*"); List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }

        // GET: Activities
        public ActionResult Index()
        {
            var activities = db.Activities.Include(a => a.ActivityType).Include(a => a.Module);
            return View(activities.ToList());
        }

        // GET: Activities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "DocumentTypeName");
            ViewBag.DocumentActivity = db.Documents.Where(d => d.ActivityId == id).ToList();
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest()) return PartialView(activity);
            return View(activity);
        }

        // GET: Activities/Create
        public ActionResult Create(int? id)
        {

            if (id == null)
            {
                ViewBag.ModuleId = new SelectList(db.Moduls, "Id", "ModulName");
            }
            else
            {
                Modul modul = db.Moduls.Find(id);
                ViewData["Id"] = id;
                ViewData["ModulName"] = modul.ModulName;
                ViewData["ModulStart"] = modul.ModulStart;
                ViewData["ModulEnd"] = modul.ModulEnd;
            }

            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName");
            if (Request.IsAjaxRequest()) return PartialView();

            return PartialView();
            //return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ActivityName,ActivityStart,ActivityEnd,ActivityDescription,ActivityTypeId,ModuleId")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName", activity.ActivityTypeId);
            ViewBag.ModuleId = new SelectList(db.Moduls, "Id", "ModulName", activity.ModuleId);
            return PartialView(activity);
        }

        // GET: Activities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName", activity.ActivityTypeId);
            ViewBag.ModuleId = new SelectList(db.Moduls, "Id", "ModulName", activity.ModuleId);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ActivityName,ActivityStart,ActivityEnd,ActivityDescription,ActivityTypeId,ModuleId")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityTypeId = new SelectList(db.ActivityTypes, "Id", "ActivityTypeName", activity.ActivityTypeId);
            ViewBag.ModuleId = new SelectList(db.Moduls, "Id", "ModulName", activity.ModuleId);
            return View(activity);
        }

        // GET: Activities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
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
