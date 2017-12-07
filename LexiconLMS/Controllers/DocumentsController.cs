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

namespace LexiconLMS.Controllers
{
    public class DocumentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult UploadIndex(HttpPostedFileBase postedFile)
        {
            foreach (string upload in Request.Files)
            {
                
                var test = HttpContext.Request.Params["testname"];
                if (Request.Files[upload].FileName != "")
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/uploads/";
                    string filename = Path.GetFileName(Request.Files[upload].FileName);
                    Request.Files[upload].SaveAs(Path.Combine(path, filename));
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
        //public FileResult Download(string ImageName)
        //{
        //    var FileVirtualPath = "~/App_Data/uploads/" + ImageName;
        //    return File(FileVirtualPath, "application/force - download", Path.GetFileName(FileVirtualPath));
        //}

        // GET: Documents
        public ActionResult Index()
        {
            var documents = db.Documents.Include(d => d.Activity).Include(d => d.Course).Include(d => d.DocumentType).Include(d => d.Modul);
            return View(documents.ToList());
        }

        // GET: Documents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Documents/Create
        public ActionResult Create()
        {
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName");
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "DocumentTypeName");
            ViewBag.ModulId = new SelectList(db.Moduls, "Id", "ModulName");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,TimeStamp,UserId,Deadline,FileName,DocumentTypeId,CourseId,ModulId,ActivityId")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Documents.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", document.ActivityId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", document.CourseId);
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "DocumentTypeName", document.DocumentTypeId);
            ViewBag.ModulId = new SelectList(db.Moduls, "Id", "ModulName", document.ModulId);
            return View(document);
        }

        // GET: Documents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", document.ActivityId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", document.CourseId);
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "DocumentTypeName", document.DocumentTypeId);
            ViewBag.ModulId = new SelectList(db.Moduls, "Id", "ModulName", document.ModulId);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,TimeStamp,UserId,Deadline,FileName,DocumentTypeId,CourseId,ModulId,ActivityId")] Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", document.ActivityId);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", document.CourseId);
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "DocumentTypeName", document.DocumentTypeId);
            ViewBag.ModulId = new SelectList(db.Moduls, "Id", "ModulName", document.ModulId);
            return View(document);
        }

        // GET: Documents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
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
