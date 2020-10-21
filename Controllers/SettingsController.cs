using MEGAPos.Models;
using MEGAPos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MEGAPos.Controllers
{
    public class SettingsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }

        #region
        //SaleTypes
        public ActionResult CreateSaleType()
        {
            var saleTypeList = db.SalesTypes.ToList();
            var settinngsVM = new SettingsViewModel()
            {
                SalesTypes = saleTypeList
            };
            return View();
        }

        public ActionResult SaleTypeIndex()
        {
            var saleList = db.SalesTypes.ToList();
            var settings = new SettingsViewModel()
            {
                SalesTypes = saleList
            };
            return View(settings);
        }

        [HttpPost]
        public ActionResult CreateSaleType(FormCollection form)
        {
            var saleType = new SalesType();

            saleType.SaleName = form["SaleName"];

            db.SalesTypes.Add(saleType);

            db.SaveChanges();

            return RedirectToAction("Index", "Users");

        }

        public ActionResult EditSaleType(int id)
        {
            var SaleType = db.SalesTypes.Find(id);

            return View(SaleType);
        }

        [HttpPost]
        public ActionResult EditSaleType(int id, FormCollection  form)
        {
            var SaleType = db.SalesTypes.Find(id);

            SaleType.SaleName = form["SaleName"];

            db.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        public ActionResult DeleteSaleType(int id)
        {
            var saleType = db.SalesTypes.Find(id);

            return View(saleType);
        }

        [HttpPost]
        public ActionResult DeleteSaleType(int id, FormCollection form)
        {
            var SaleType = db.SalesTypes.Find(id);

            db.SalesTypes.Remove(SaleType);

            db.SaveChanges();

            return RedirectToAction("Index", "Users");
        }

        #endregion
    }
}