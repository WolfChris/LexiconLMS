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
    public class ModulsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult UploadIndex(HttpPostedFileBase postedFile)
        {
            foreach (string upload in Request.Files)
            {

                if (Request.Files[upload].FileName != "")
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/uploads/";
                    string filename = Path.GetFileName(Request.Files[upload].FileName);
                    Request.Files[upload].SaveAs(Path.Combine(path, filename));


                    
                    int modulId = Convert.ToInt32(HttpContext.Request.Params["modulId"]);
                    int documentTypeId = Convert.ToInt32(HttpContext.Request.Params["documentTypeId"]);

                    //int documentTypeId = Convert.ToInt32(HttpContext.Request.Params["documentTypeId"].ToString());
                    db.Documents.Add(new Document
                    {
                        Name = filename,
                        TimeStamp = DateTime.Now,
                        FileName = filename,
                        DocumentTypeId = documentTypeId,
                        ModulId = modulId,
                        UserId = User.Identity.GetUserId()

                    });

                    db.SaveChanges();

                }
            }
            return View();
        }

        public ActionResult Downloads()
        {
            var dir = new DirectoryInfo(Server.MapPath("~/App_Data/uploads/"));
            FileInfo[] fileNames = dir.GetFiles("*.*"); List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }

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
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "DocumentTypeName");
            Modul modul = db.Moduls.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest()) return PartialView(modul);
            return View(modul);
        }

        // GET: Moduls/Create
        public ActionResult Create(int? id)
        {
            if (id == null) { 
            ViewBag.Courseid = new SelectList(db.Courses, "CourseId", "CourseName");                        
            
            }
            else
            {
                Course course = db.Courses.Find(id);
                ViewData["courseId"] = id;
                ViewData["courseName"] = course.CourseName;
                ViewData["coStartDate"] = course.CoStartDate;
                ViewData["coEndDate"] = course.CoEndDate;

            }
            //return PartialView();
            return View();
        }

        // POST: Moduls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModulName,ModulDescription,ModulStart,ModulEnd,Courseid")] Modul modul)
        {
            if (ModelState.IsValid)
            {
                //if(String.IsNullOrEmpty(HttpContext.Request.Params["txtCourseId"].ToString())) {
                if (HttpContext.Request.Params.AllKeys.Contains("txtCourseId"))
                { 
                    modul.Courseid = Convert.ToInt32(HttpContext.Request.Params["txtCourseId"]);
                 }
            
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
