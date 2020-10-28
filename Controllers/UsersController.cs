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
                        case "Super Distributor":
                            return RedirectToAction("Distributor", "Users");
                        case "Area Distributor":
                            return RedirectToAction("AreaDistributor", "Users");
                        case "Sales Person":
                            return RedirectToAction("SalesPerson", "Users");
                        case "Customer":
                            var customerId = user.GetUserId().ToString();
                            var customer = context.Customers.Where(m => m.User_Id == customerId).FirstOrDefault();
          
                            if (customer!=null)
                            {
                                return RedirectToAction("Customer", "Users");
                            }

                            List<SelectListItem> cusTypes = new List<SelectListItem>();
                            foreach (var unit in context.CustomerTypes)
                            {
                                cusTypes.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Name });
                            }
                            ViewBag.Custypes = cusTypes;

                            return View("CustomerBio");
                            
                        case "Vendor":
                            var vendorId = user.GetUserId().ToString();
                            var vendor = context.Vendors.Where(m => m.User_Id == vendorId).FirstOrDefault();

                            if (vendor != null)
                            {
                                return RedirectToAction("Vendor", "Users");
                            }

                            List<SelectListItem> ventypes = new List<SelectListItem>();
                            foreach (var unit in context.VendorTypes)
                            {
                                ventypes.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Name });
                            }
                            ViewBag.Ventypes = ventypes;

                            return View("VendorBio");
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

            var units = context.Units.ToList();

            var saleHeader = context.Sales_Headers.ToList();

            var saleDetails = context.Sales_Details.ToList();

            var purchaseHeader = context.Purchase_Heads.ToList();

            var purchaseDetails = context.Purchase_Details.ToList();

            var vm = new SuperAdminViewModel()
            {
                user = User.Identity.Name,
                users = users_,
                roles = Roles_,
                items = items,
                units = units,
                Sales_Header = saleHeader,
                Sales_Details = saleDetails,
                Purchase_Head = purchaseHeader,
                Purchase_Details = purchaseDetails
            };
            return View(vm);
        }

        public ActionResult Vendor()
        {
            //Vendor Dash
            var user_ = User.Identity;
            ViewBag.Name = user_.Name;
            var user_id = User.Identity.GetUserId();

            var vendor = context.Vendors.Where(m => m.User_Id == user_id).First();

            ViewBag.VendorName = vendor.Name;
            return View();
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

        public ActionResult AreaDistributor()
        {

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

            var customer = context.Customers.Where(m => m.User_Id == user_id).First();

            ViewBag.CustomerName = customer.Customer_Name;

            return View();
        }

        //Edit User
        public ActionResult EditUser(string id)
        {
            var user = context.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(string id, FormCollection form)
        {
            var user = context.Users.Find(id);

            if (user!=null)
            {
                user.UserName = form["Fullname"];
                user.Email = form["Email"];
                user.PhoneNumber = form["PhoneNumber"];
            }
            return RedirectToAction("Index", "Users");
        }


        #region CUSTOMER BIO
        [HttpPost]
        public ActionResult CreateCustomerBio(FormCollection form)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());

                var customer = new Customers();

                if (ModelState.IsValid)
                {
                    customer.Customer_Name = form["Customer_Name"];
                    customer.Contact = form["Contact"];
                    customer.Address = form["Address"];
                    customer.CustomerType_Id = Convert.ToInt32(form["CustomerType_Id"]);
                    customer.User_Id = user.GetUserId();

                    context.Customers.Add(customer);
                    context.SaveChanges();

                }

            }

            return RedirectToAction("Index", "Users");


        }
        #endregion

        #region VENDOR BIO
        [HttpPost]
        public ActionResult CreateVendorBio(FormCollection form)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());

                var vendor = new Vendor();

                if (ModelState.IsValid)
                {
                    vendor.Name = form["Name"];
                    vendor.Contact = form["Contact"];
                    vendor.Address = form["Address"];
                    vendor.Vendor_TypeID = Convert.ToInt32(form["Vendor_TypeID"]);
                    vendor.User_Id = user.GetUserId();

                    context.Vendors.Add(vendor);
                    context.SaveChanges();

                }

            }

            return RedirectToAction("Index", "Users");


        }
        #endregion
    }
}