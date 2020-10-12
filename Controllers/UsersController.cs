using MEGAPos.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEGAPos.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private ApplicationDbContext context;

        public UsersController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Users
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;


                
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());

                foreach (var item in s)
                {
                    switch (item)
                    {
                        case "Super Admin":
                            return RedirectToAction("SuperAdmin", "Users");
                        case "Sales Admin":
                            return RedirectToAction("SalesAdmin", "Users");
                        case "Distributor":
                            return RedirectToAction("Distributor", "Users");
                        case "Sales Person":
                            return RedirectToAction("SalesPerson", "Users");
                        case "Customer":
                            return RedirectToAction("Customer", "Users");
                        default:
                            return RedirectToAction("Index", "Home");
                    }
                }


                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged IN";
            }
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        public ActionResult SuperAdmin()
        {
            var user_ = User.Identity;
            ViewBag.Name = user_.Name;
            context = new ApplicationDbContext();
            //Super Admin Dashboard
            var Roles_ = context.Roles.ToList();

            var users_ = context.Users.ToList();

            var items = context.Items.ToList();

            var vm = new SuperAdminViewModel()
            {
                user = User.Identity.Name,
                users = users_, 
                roles = Roles_,
                items = items
            };
            return View(vm);
        }

        public ActionResult SalesAdmin()
        {
            var roleId = "8b227d04-a11e-4ba8-8601-4be9ab12ef9d";

            var user_ = User.Identity;
            ViewBag.Name = user_.Name;
            context = new ApplicationDbContext();
            //Super Admin Dashboard
            var Roles_id = context.Roles.Find(roleId);


            var users_ = context.Users.ToList();

            var vm = new SalesAdminViewModel()
            {
                user = user_.Name,
                users = users_  
            };
            return View(vm);
        }

        public ActionResult Distributor()
        {
            
            var user_ = User.Identity;
            ViewBag.Name = user_.Name;
            var user_id = User.Identity.GetUserId();

            //var company = context.Distributors.Where(x => x.Distirbutor_Id == user_id).FirstOrDefault();

            //if (company==null)
            //{
            //    return RedirectToAction("Create", "Distribution");
            //}
            //context = new ApplicationDbContext();
            ////Super Admin Dashboard
            //var Roles_ = context.Roles.ToList();

            //var users_ = context.Users.ToList();

            //var vm = new SalesAdminViewModel()
            //{
            //    user = user_.Name
            //};
            return View();
        }

        public ActionResult SalesPersons()
        {

            var user_ = User.Identity;
            ViewBag.Name = user_.Name;
            var user_id = User.Identity.GetUserId();

            //var company = context.Distributors.Where(x => x.Distirbutor_Id == user_id).FirstOrDefault();

            //if (company==null)
            //{
            //    return RedirectToAction("Create", "Distribution");
            //}
            //context = new ApplicationDbContext();
            ////Super Admin Dashboard
            //var Roles_ = context.Roles.ToList();

            //var users_ = context.Users.ToList();

            //var vm = new SalesAdminViewModel()
            //{
            //    user = user_.Name
            //};
            return View();
        }

        public ActionResult Customer()
        {

            var user_ = User.Identity;
            ViewBag.Name = user_.Name;
            var user_id = User.Identity.GetUserId();

            //var company = context.Distributors.Where(x => x.Distirbutor_Id == user_id).FirstOrDefault();

            //if (company==null)
            //{
            //    return RedirectToAction("Create", "Distribution");
            //}
            //context = new ApplicationDbContext();
            ////Super Admin Dashboard
            //var Roles_ = context.Roles.ToList();

            //var users_ = context.Users.ToList();

            //var vm = new SalesAdminViewModel()
            //{
            //    user = user_.Name
            //};
            return View();
        }
    }
}