﻿using LexiconLMS.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LexiconLMS.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student
        public ActionResult Index()
        {
            {
                var user = db.Users.Find(User.Identity.GetUserId());
                
                var course = db.Courses.Where(m => m.CourseId == user.CourseId).FirstOrDefault();
                

                TempData["name"] =  user.FirstName + " " + user.LastName;
                return View(course);
            }
        }
    }
}