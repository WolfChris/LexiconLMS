namespace LexiconLMS.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LexiconLMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LexiconLMS.Models.ApplicationDbContext context)
        {

            context.Courses.AddOrUpdate(
                  c => c.CourseName,
                  new Course
                  {
                      CourseName = "MVC Advanced",
                      CoStartDate = Convert.ToDateTime("2018-01-06"),
                      CoEndDate = Convert.ToDateTime("2018-05-29"),
                      Description = "Visual Studio 2017 MVC Course"
                  },
                    new Course
                    {
                        CourseName = "Java fundamentals",
                        CoStartDate = Convert.ToDateTime("2018-01-20"),
                        CoEndDate = Convert.ToDateTime("2018-04-30"),
                        Description = "Learning Java for the Web"
                    }
                );

            context.SaveChanges();

            //var Course1 = context.Courses.Find("MVC Advanced");
            var Course1 = context.Courses.SingleOrDefault(c => c.CourseName == "MVC Advanced");
            int c1 = Course1.CourseId;

            var Course2 = context.Courses.SingleOrDefault(c => c.CourseName == "Java fundamentals");
            int c2 = Course2.CourseId;

            context.Moduls.AddOrUpdate(
              m => m.ModulName,
              new Modul
              {
                  Courseid = c1,
                  ModulName = "Bootstrap 3",
                  ModulStart = Convert.ToDateTime("2018-02-02"),
                  ModulEnd = Convert.ToDateTime("2018-03-02"),
                  ModulDescription = "Fundamentals in Bootstrap"
              },
              new Modul
              {
                  Courseid = c1,
                  ModulName = "jQuery",
                  ModulStart = Convert.ToDateTime("2018-04-15"),
                  ModulEnd = Convert.ToDateTime("2018-04-30"),
                  ModulDescription = "JQuery from scratch"
              },
              new Modul
              {
                  Courseid = c2,
                  ModulName = "javascript",
                  ModulStart = Convert.ToDateTime("2018-02-10"),
                  ModulEnd = Convert.ToDateTime("2018-03-07"),
                  ModulDescription = "Fundamentals in javascript"
              },
              new Modul
              {
                  Courseid = c2,
                  ModulName = "Apache",
                  ModulStart = Convert.ToDateTime("2018-04-01"),
                  ModulEnd = Convert.ToDateTime("2018-04-15"),
                  ModulDescription = "Apache server for dummies"
              }
              );

            context.SaveChanges();

            var Modul1 = context.Moduls.SingleOrDefault(m => m.ModulName == "Bootstrap 3");
            int m1 = Modul1.Id;

            var Modul2 = context.Moduls.SingleOrDefault(m => m.ModulName == "jQuery");
            int m2 = Modul2.Id;

            var Modul3 = context.Moduls.SingleOrDefault(m => m.ModulName == "javascript");
            int m3 = Modul3.Id;

            var Modul4 = context.Moduls.SingleOrDefault(m => m.ModulName == "Apache");
            int m4 = Modul4.Id;

            context.ActivityTypes.AddOrUpdate(
                m => m.ActivityTypeName,
                new ActivityType
                {                    
                    ActivityTypeName = "Föreläsning",
                    ActivityTypeDescription = "Föreläsning"
                },
                new ActivityType
                {
                    ActivityTypeName = "Inlämningsuppgift",
                    ActivityTypeDescription = "Inlämningsuppgift"
                },
                new ActivityType
                {
                    ActivityTypeName = "E-Learning",
                    ActivityTypeDescription = "E-Learning"
                }
                );
                context.SaveChanges();

            var ActivityType1 = context.ActivityTypes.SingleOrDefault(at => at.ActivityTypeName == "Föreläsning");
            int at1 = ActivityType1.Id;

            var ActivityType2 = context.ActivityTypes.SingleOrDefault(at => at.ActivityTypeName == "Inlämningsuppgift");
            int at2 = ActivityType2.Id;

            var ActivityType3 = context.ActivityTypes.SingleOrDefault(at => at.ActivityTypeName == "E-Learning");
            int at3 = ActivityType3.Id;

            context.Activities.AddOrUpdate(
                a => a.ActivityName,
                new Activity
                {
                    ActivityName = "Föreläsning m4-1",
                    ActivityStart = Convert.ToDateTime("2018-04-01"),
                    ActivityEnd = Convert.ToDateTime("2018-04-01"),
                    ActivityDescription = "Intro to Apache",
                    ActivityTypeId = at1,
                    ModuleId = m4
                },
                new Activity
                {
                    ActivityName = "E-Learning m4-1",
                    ActivityStart = Convert.ToDateTime("2018-04-02"),
                    ActivityEnd = Convert.ToDateTime("2018-04-02"),
                    ActivityDescription = "Practical Apache Applications",
                    ActivityTypeId = at3,
                    ModuleId = m4
                },
                 new Activity
                 {
                     ActivityName = "Föreläsning m3-1",
                     ActivityStart = Convert.ToDateTime("2018-02-10"),
                     ActivityEnd = Convert.ToDateTime("2018-02-10"),
                     ActivityDescription = "Intro to Javascript",
                     ActivityTypeId = at1,
                     ModuleId = m3
                 },
                new Activity
                {
                    ActivityName = "E-Learning m3-1",
                    ActivityStart = Convert.ToDateTime("2018-02-11"),
                    ActivityEnd = Convert.ToDateTime("2018-02-11"),
                    ActivityDescription = "Practical Javascript Applications",
                    ActivityTypeId = at3,
                    ModuleId = m3
                },

                new Activity
                {
                    ActivityName = "Föreläsning m2-1",
                    ActivityStart = Convert.ToDateTime("2018-04-15"),
                    ActivityEnd = Convert.ToDateTime("2018-04-15"),
                    ActivityDescription = "Intro to jQuery",
                    ActivityTypeId = at1,
                    ModuleId = m2
                },
                new Activity
                {
                    ActivityName = "E-Learning m2-1",
                    ActivityStart = Convert.ToDateTime("2018-04-16"),
                    ActivityEnd = Convert.ToDateTime("2018-04-16"),
                    ActivityDescription = "Practical jQuery Applications",
                    ActivityTypeId = at3,
                    ModuleId = m2
                },

                new Activity
                {
                    ActivityName = "Föreläsning m1-1",
                    ActivityStart = Convert.ToDateTime("2018-02-02"),
                    ActivityEnd = Convert.ToDateTime("2018-02-02"),
                    ActivityDescription = "Intro to Bootstrap",
                    ActivityTypeId = at1,
                    ModuleId = m1
                },
                new Activity
                {
                    ActivityName = "E-Learning m1-1",
                    ActivityStart = Convert.ToDateTime("2018-02-03"),
                    ActivityEnd = Convert.ToDateTime("2018-02-03"),
                    ActivityDescription = "Practical Bootstrap Applications",
                    ActivityTypeId = at3,
                    ModuleId = m1
                }
                );

            context.SaveChanges();

            var userStore = new UserStore<ApplicationUser>(context);
            var UserManager = new UserManager<ApplicationUser>(userStore);

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string password = "Password@1234!";

            //Create Role Teacher and Student if it does not exist
            var roleNames = new[] { "Teacher", "Student" };
            foreach (var roleName in roleNames)
            {
                if (!RoleManager.RoleExists(roleName))
                {
                    var roleresult = RoleManager.Create(new IdentityRole(roleName));
                }
            }

            context.SaveChanges();
            //Create Teacher user and Students

            var users = new[] { "admin1@admin1.com", "student1@lexicon.se", "student2@lexicon.se", "student3@lexicon.se" };

            foreach (var user in users)
            {
                if (context.Users.Any(u => u.UserName == user)) continue;
                if (user != "admin1@admin1.com")
                {
                    password = "Student@1234";
                }
                var admin1 = new ApplicationUser { UserName = user, Email = user };
                UserManager.Create(admin1, password);
            }

            context.SaveChanges();

            var teacherUser = UserManager.FindByName("admin1@admin1.com");
            UserManager.AddToRole(teacherUser.Id, "Teacher");

            var studentUser1 = UserManager.FindByName("student1@lexicon.se");
            UserManager.AddToRole(studentUser1.Id, "Student");

            var studentUser2 = UserManager.FindByName("student2@lexicon.se");
            UserManager.AddToRole(studentUser2.Id, "Student");

            var studentUser3 = UserManager.FindByName("student3@lexicon.se");
            UserManager.AddToRole(studentUser3.Id, "Student");


            context.SaveChanges();

            context.DocumentTypes.AddOrUpdate(
              d => d.DocumentTypeName,
              new DocumentType {
                  DocumentTypeName = "Kursdokument"
              },
              new DocumentType {
                  DocumentTypeName = "Inlämningsuppgift"
              },
              new DocumentType
              {
                  DocumentTypeName = "Moduldokument"
              },
              new DocumentType
              {
                  DocumentTypeName = "Aktivitetsdokument"
              },
              new DocumentType
              {
                  DocumentTypeName = "Föreläsningsunderlag"
              }
            );

            context.SaveChanges();

        }

    }
    }

