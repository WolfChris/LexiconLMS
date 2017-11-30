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
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));


            string role = "Teacher";
            string password = "Password@1234";

            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(role))
            {
                var roleresult = RoleManager.Create(new IdentityRole(role));
            }

            //Create Admin users with password=123456
            var admin1 = new ApplicationUser();
            admin1.UserName = "admin1@admin1.com";
            admin1.Email = "admin1@admin1.com";
            admin1.EmailConfirmed = true;
            UserManager.Create(admin1, password);
            admin1 = context.Users.FirstOrDefault(x => x.UserName == admin1.UserName);


            UserManager.AddToRole(admin1.Id, role);
           
            context.SaveChanges();



            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //string role = "Student";
            //string password = "Student@123";

            ////Create Role Admin if it does not exist
            //if (!RoleManager.RoleExists(role))
            //{
            //    var roleresult = RoleManager.Create(new IdentityRole(role));
            //}

            ////Create Admin users with password=123456
            //var student1 = new ApplicationUser();
            //student1.UserName = "student@admin.com";
            //student1.Email = "student@admin.com";
            //student1.EmailConfirmed = true;
            //UserManager.Create(student1, password);
            //student1 = context.Users.FirstOrDefault(x => x.UserName == student1.UserName);


            //UserManager.AddToRole(student1.Id, role);


            //context.SaveChanges();


            
        }
    }
}
