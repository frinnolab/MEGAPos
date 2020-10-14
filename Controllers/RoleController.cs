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
    public class RoleController : Controller
    {
        private ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }
        
        // GET: Role
        public ActionResult Index()
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            
            try
            {
                context.Roles.Add(role);
                var a = 0;

                context.SaveChanges();
                // TODO: Add insert logic here
       
                return RedirectToAction("Index", "Users");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: Role/Edit/5
        public ActionResult EditRole(string id)
        {
            var role = context.Roles.Find(id);

            var a = 0;
            return View(role);
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult EditRole(string id, FormCollection collection)
        {

            var role = context.Roles.Find(id);
            try
            {
                // TODO: Add update logic here

                role.Name = collection["Name"];

                context.SaveChanges();

                return RedirectToAction("Index", "Users");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Delete/5
        public ActionResult DeleteRole(string id)
        {
            var role = context.Roles.Find(id);
            return View(role);
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult DeleteRole(string id, FormCollection collection)
        {
            var role = context.Roles.Find(id);
            try
            {
                context.Roles.Remove(role);
                context.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index", "Users");
            }
            catch
            {
                return View();
            }
        }
    }
}
