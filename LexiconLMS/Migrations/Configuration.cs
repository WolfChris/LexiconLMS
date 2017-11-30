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
            //  This method will be called after migrating to the latest version.


            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
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

            var userStore = new UserStore<ApplicationUser>(context);
            var UserManager = new UserManager<ApplicationUser>(userStore);
            
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            
            string password = "Password@1234";

            //Create Role Teacher and Student if it does not exist
            var roleNames = new[] { "Teacher", "Student" };
            foreach (var roleName in roleNames) { 
                if (!RoleManager.RoleExists(roleName))
            {
                var roleresult = RoleManager.Create(new IdentityRole(roleName));
            }
            }

            context.SaveChanges();
            //Create Teacher user and Students

            var users = new[] { "admin1@admin1.com", "student1@lexicon.se", "student2@lexicon.se", "student3@lexicon.se" };

            foreach(var user in users) {
                if (context.Users.Any(u => u.UserName == user)) continue;
                if(user != "admin1@admin1.com") {
                    password = "Student@1234";
                }
                var admin1 = new ApplicationUser { UserName = user, Email = user, PasswordHash = password, EmailConfirmed = true };
                UserManager.Create(admin1);
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
        }
    }
}
