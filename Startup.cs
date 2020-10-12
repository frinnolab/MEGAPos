using System;
using MEGAPos.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MEGAPos.Startup))]
namespace MEGAPos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //Roles
            CreatRoleAndUser();
        }

        private void CreatRoleAndUser()
        {
            //
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("SuperAdmin"))
            {
                var role = new IdentityRole();
                role.Name = "Super Admin";
                roleManager.Create(role);

                //Super Admin
                var user = new ApplicationUser();
                user.UserName = "Frinno";
                user.Email = "dev.frinno@gmail.com";
                string password = "123abc";
                var checkUser = userManager.Create(user, password);

                if (checkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "Super Admin");
                }
            }

            if (!roleManager.RoleExists("SalesAdmin"))
            {
                var role = new IdentityRole();
                role.Name = "Sales Admin";
                roleManager.Create(role);
            }


        }
    }
}
