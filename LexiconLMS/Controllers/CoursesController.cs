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
    [Authorize(Roles = "Teacher")]
    public class CoursesController : Controller
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



                    int courseId = Convert.ToInt32(HttpContext.Request.Params["courseId"]);
                    int documentTypeId = Convert.ToInt32(HttpContext.Request.Params["documentTypeId"]);

                    //int documentTypeId = Convert.ToInt32(HttpContext.Request.Params["documentTypeId"].ToString());
                    db.Documents.Add(new Document
                    {
                        Name = filename,
                        TimeStamp = DateTime.Now,
                        FileName = filename,
                        DocumentTypeId = documentTypeId,
                        CourseId = courseId,
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

        // GET: Courses
        public ActionResult Index()
        {
            
            return View(db.Courses.ToList());
        }

        //public FileContentResult ProcessImage(byte[] imageToProcess)
        //{
        //    return new FileContentResult(imageToProcess, "image/jpeg");
        //}
        // To convert the Byte Array to the author Image
        //public FileContentResult GetImg(string id)
        //{
        //    byte[] byteArray = db.Users.Find(id).Image;
        //    return byteArray != null
        //        ? new FileContentResult(byteArray, "image/jpeg")
        //        : null;
        //}
        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            //TempData["course"] = course.CourseName;
            //TempData["courseDescription"] = course.Description;            
            ViewBag.UserCourse = db.Users.Where(u => u.CourseId == id).ToList();
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "DocumentTypeName");
            ViewBag.CourseModuls = db.Moduls.Where(i => i.Courseid == id).ToList();
            ViewBag.DocumentCourse = db.Documents.Where(d => d.CourseId == id).ToList();
            if (course == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest()) return PartialView(course);
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseName,CoStartDate,CoEndDate,Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return PartialView(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseName,CoStartDate,CoEndDate,Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return PartialView(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
