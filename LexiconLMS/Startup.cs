using LexiconLMS.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LexiconLMS.Startup))]
namespace LexiconLMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }


        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //    // In Startup iam creating first Admin Role and creating a default Admin User    
            //if (!roleManager.RoleExists("Teacher"))
            //{

            //    //first we create Admin rool
            //    var role = new IdentityRole();
            //    role.Name = "Teacher";
            //    roleManager.Create(role);

            //Here we create a Admin super user who will maintain the website

            //    var user = new ApplicationUser();
            //    user.UserName = "admin@gmail.com";
            //    user.Email = "admin@gmail.com";

            //    string userPWD = "Admin@gmail.com";

            //    var chkUser = UserManager.Create(user, userPWD);

            //    //Add default User to Role Admin   
            //    if (chkUser.Succeeded)
            //    {
            //        var result1 = UserManager.AddToRole(user.Id, "Teacher");

            //    }
            //}

            //        var user = new ApplicationUser();
            //        user.UserName = "student@gmail.com";
            //        user.Email = "student@gmail.com";

            //        string userPWD = "Student@gmail.com";

            //        var chkUser = UserManager.Create(user, userPWD);

            //        if (chkUser.Succeeded)
            //        {
            //            var result1 = UserManager.AddToRole(user.Id, "Student");

            //        }
        }

    }
}

// creating Creating Student role    
//if (!roleManager.RoleExists("Student"))
//{
//    var role = new IdentityRole();
//    role.Name = "Student";
//    roleManager.Create(role);

//}
//**admin1 = Password@1234

//    if (!roleManager.RoleExists("Teacher"))
//    {
//        var role = new IdentityRole();
//        role.Name = "Teacher";
//        roleManager.Create(role);

//        var user = new ApplicationUser();
//        user.UserName = "Teacher1";
//        user.Email = "teacher@teaches.com";

//        string userPWD = "teacher";               

//    }

//}


