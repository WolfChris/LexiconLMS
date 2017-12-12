using LexiconLMS.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LexiconLMS.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        public ActionResult Index()
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            var modul = db.Moduls.Where(m => m.Courseid == user.CourseId);
            var course = db.Courses.Where(m => m.CourseId == user.CourseId).FirstOrDefault();

            TempData["name"] = user.FirstName + " " + user.LastName;
            TempData["courseName"] = course.CourseName;
            TempData["CourseStart"] = course.CoStartDate;
            TempData["courseEnd"] = course.CoStartDate;
            TempData["courseDescription"] = course.Description;

            return View(modul.ToList());
        }

      
    

    //public ActionResult Assigments()
    //{
    //        var user = db.Users.Find(User.Identity.GetUserId());
    //        var modul = db.Moduls.Where(x => x.Courseid == user.CourseId).Select(y => y.Activities.Where(a => a.ActivityTypeId == 2));
            
    //        return View(modul);
    //}
}
}