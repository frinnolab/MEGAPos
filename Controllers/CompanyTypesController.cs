using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MEGAPos.Models;

namespace MEGAPos.Controllers
{
    public class CompanyTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CompanyTypes
        public ActionResult Index()
        {
            return View(db.CompanyTypes.ToList());
        }

        // GET: CompanyTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyType companyType = db.CompanyTypes.Find(id);
            if (companyType == null)
            {
                return HttpNotFound();
            }
            return View(companyType);
        }

        // GET: CompanyTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] CompanyType companyType)
        {
            if (ModelState.IsValid)
            {
                db.CompanyTypes.Add(companyType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyType);
        }

        // GET: CompanyTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyType companyType = db.CompanyTypes.Find(id);
            if (companyType == null)
            {
                return HttpNotFound();
            }
            return View(companyType);
        }

        // POST: CompanyTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] CompanyType companyType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyType);
        }

        // GET: CompanyTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyType companyType = db.CompanyTypes.Find(id);
            if (companyType == null)
            {
                return HttpNotFound();
            }
            return View(companyType);
        }

        // POST: CompanyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyType companyType = db.CompanyTypes.Find(id);
            db.CompanyTypes.Remove(companyType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
