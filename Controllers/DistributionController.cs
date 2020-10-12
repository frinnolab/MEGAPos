using MEGAPos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEGAPos.Controllers
{
    [Authorize]
    public class DistributionController : Controller
    {
        private ApplicationDbContext db;
        // GET: Distribution
        public ActionResult Index()
        {
            var companies = db.Distributors.ToList();
            return View(companies);
        }

        // GET: Distribution/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Distribution/Create
        public ActionResult Create()
        {
            var company = new Distributor();
            var companyAdmninId = company.Distirbutor_Id;
            var user_ = User.Identity;
            var vm = new DistributorViewModel() {
                User= user_.Name,
                Distributor = company,
            };
            return View(vm);
        }

        // POST: Distribution/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Distribution/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Distribution/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Distribution/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Distribution/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
