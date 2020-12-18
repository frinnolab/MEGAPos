﻿using System;
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
    public class CompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Companies
        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {

            List<SelectListItem> unitlist = new List<SelectListItem>();
            foreach (var unit in db.CompanyTypes)
            {
                unitlist.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.Name });
            }

            List<SelectListItem> location_list = new List<SelectListItem>();
            foreach (var unit in db.StoreLocations)
            {
                location_list.Add(new SelectListItem() { Value = unit.Id.ToString(), Text = unit.StoreName });
            }

            ViewBag.CompanyTypes = unitlist;

            ViewBag.LocationList = location_list;

            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Contact,Email,CompanyTypeId, Location_Id")] Company company)
        {
            string locationName, companyTypeName;
            //check for Location Name
            if (company.Location_Id!=null)
            {
                locationName = db.StoreLocations.Find(company.Location_Id).StoreName.ToString();

                company.Location = locationName;
            }


            if (company.CompanyTypeId !=null)
            {
                companyTypeName = db.CompanyTypes.Find(company.CompanyTypeId).Name.ToString();

                company.Company_Type_Name = companyTypeName;
            }
      

            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index","Users");
            }

            //return View(company);

            return RedirectToAction("Index", "Users");
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Contact,Email,CompanyTypeId,Company_Type_Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //return View(company);

            return RedirectToAction("Index", "Users");
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            //return RedirectToAction("Index");

            return RedirectToAction("Index", "Users");
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
